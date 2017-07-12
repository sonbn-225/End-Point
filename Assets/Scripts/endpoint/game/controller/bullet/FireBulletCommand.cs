using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using strange.extensions.pool.api;
using UnityEngine;

namespace endpoint.game
{
	public class FireBulletCommand : Command
	{
        [Inject]
        public Vector3 pos { get; set; }

        [Inject]
        public GameObject target { get; set; }

        [Inject]
        public GameElement id { get; set; }

        [Inject]
        public float damage { get; set; }

        [Inject(GameElement.GAME_FIELD)]
        public GameObject gameField { get; set; }

        [Inject(GameElement.ENEMY_BULLET_POOL)]
        public IPool<GameObject> enemyBulletPool { get; set; }

        [Inject(GameElement.TOWER_BULLET_POOL)]
        public IPool<GameObject> towerBulletPool { get; set; }

        [Inject]
        public IGameModel gameModel { get; set; }

        [Inject]
        public ITower towerData { get; set; }

        private bool isKillEnemy = false;

        public override void Execute()
        {
            if (!gameModel.isGameOver)
            {
				GameObject bulletGO = (id == GameElement.ENEMY_BULLET_POOL) ? enemyBulletPool.GetInstance() : towerBulletPool.GetInstance();
				bulletGO.transform.position = pos;
				bulletGO.transform.localScale = (id == GameElement.ENEMY_BULLET_POOL) ? new Vector3(0.25f, 0.25f, 0.25f) : new Vector3(0.5f, 0.5f, 0.5f);
				bulletGO.transform.parent = gameField.transform;
				bulletGO.GetComponent<BulletView>().Init(gameModel.gameSpeed);
				if (id == GameElement.ENEMY_BULLET_POOL)
				{
					towerData.health -= damage;
                    if (towerData.health <= 0)
                    {
                        isKillEnemy = true;
                    } else
                    {
                        isKillEnemy = false;
                    }
				}
				else
				{
					target.GetComponent<EnemyView>().data.health -= damage;
					if (target.GetComponent<EnemyView>().data.health <= 0)
					{
						isKillEnemy = true;
					}
					else
					{
						isKillEnemy = false;
					}
				}
				bulletGO.GetComponent<BulletView>().data = new Bullet()
				{
					targetObject = target,
					targetPosition = FirstOrderIntercept(pos, Vector3.zero, 20f * gameModel.gameSpeed, target.transform.position, Vector3.zero),
					isKillEnemy = isKillEnemy,
					speed = 40f * gameModel.gameSpeed
				};
				bulletGO.SetActive(true);
            }
        }

		//first-order intercept using absolute target position
		public static Vector3 FirstOrderIntercept(Vector3 shooterPosition, Vector3 shooterVelocity, float shotSpeed, Vector3 targetPosition, Vector3 targetVelocity)
		{
			Vector3 targetRelativePosition = targetPosition - shooterPosition;
			Vector3 targetRelativeVelocity = targetVelocity - shooterVelocity;
			float t = FirstOrderInterceptTime
			(
				shotSpeed,
				targetRelativePosition,
				targetRelativeVelocity
			);
			return targetPosition + t * (targetRelativeVelocity);
		}

		//first-order intercept using relative target position
		public static float FirstOrderInterceptTime(float shotSpeed, Vector3 targetRelativePosition, Vector3 targetRelativeVelocity)
		{
			float velocitySquared = targetRelativeVelocity.sqrMagnitude;
			if (velocitySquared < 0.001f)
				return 0f;

			float a = velocitySquared - shotSpeed * shotSpeed;

			//handle similar velocities
			if (Mathf.Abs(a) < 0.001f)
			{
				float t = -targetRelativePosition.sqrMagnitude /
				(
					2f * Vector3.Dot
					(
						targetRelativeVelocity,
						targetRelativePosition
					)
				);
				return Mathf.Max(t, 0f); //don't shoot back in time
			}

			float b = 2f * Vector3.Dot(targetRelativeVelocity, targetRelativePosition);
			float c = targetRelativePosition.sqrMagnitude;
			float determinant = b * b - 4f * a * c;

			if (determinant > 0f)
			{ //determinant > 0; two intercept paths (most common)
				float t1 = (-b + Mathf.Sqrt(determinant)) / (2f * a),
						t2 = (-b - Mathf.Sqrt(determinant)) / (2f * a);
				if (t1 > 0f)
				{
					if (t2 > 0f)
						return Mathf.Min(t1, t2); //both are positive
					else
						return t1; //only t1 is positive
				}
				else
					return Mathf.Max(t2, 0f); //don't shoot back in time
			}
			else if (determinant < 0f) //determinant < 0; no intercept path
				return 0f;
			else //determinant = 0; one intercept path, pretty much never happens
				return Mathf.Max(-b / (2f * a), 0f); //don't shoot back in time
		}
	}
}

