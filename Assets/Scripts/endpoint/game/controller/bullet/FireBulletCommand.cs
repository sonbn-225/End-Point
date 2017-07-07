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
        public GameObject towerGO { get; set; }

        [Inject]
        public GameObject targetEnemy { get; set; }

        [Inject]
        public GameElement id { get; set; }

        [Inject(GameElement.GAME_FIELD)]
        public GameObject gameField { get; set; }

        [Inject(GameElement.ENEMY_BULLET_POOL)]
        public IPool<GameObject> enemyBulletPool { get; set; }

        [Inject(GameElement.TOWER_BULLET_POOL)]
        public IPool<GameObject> towerBulletPool { get; set; }

        [Inject]
        public IGameModel gameModel { get; set; }

        private bool isKillEnemy = false;

        public override void Execute()
        {
            GameObject bulletGO = (id == GameElement.ENEMY_BULLET_POOL) ? enemyBulletPool.GetInstance() : towerBulletPool.GetInstance();

            bulletGO.transform.localPosition = towerGO.transform.localPosition;
            bulletGO.transform.parent = gameField.transform;
            bulletGO.GetComponent<BulletView>().data = new Bullet()
            {
                enemy = targetEnemy.GetComponent<EnemyView>(),
                target = FirstOrderIntercept(bulletGO.transform.position, Vector3.zero, 20f * gameModel.gameSpeed, targetEnemy.transform.localPosition, Vector3.zero),
                isKillEnemy = isKillEnemy,
                speed = 40f*gameModel.gameSpeed
            };
            bulletGO.SetActive(true);
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

