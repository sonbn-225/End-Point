using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace endpoint.game
{
	public class EnemyView : View
	{
		public IEnemy data { get; set; }
        public GameObject normalForm, fastForm, bigForm, strongForm;

        //These Signals inform the Mediator that certain events have occurred
        internal Signal enterAttackRangeSignal = new Signal();
        internal Signal enemyAttackSignal = new Signal();

        float distance, timer = 1f;
        int gameSpeed;
        bool isGameOver, isInTowerAttackRange, isInAttackRange, isReachTower;

        public void Init(bool isGameOver, int gameSpeed)
		{
            SetEnemyForm(data.enemyType);
            this.gameSpeed = gameSpeed;
            this.isGameOver = isGameOver;
            distance = Vector3.Distance(gameObject.transform.position, data.targetPosition);
            if (distance > data.towerAttackRange)
            {
                isInTowerAttackRange = false;
                isInAttackRange = false;
                isReachTower = false;
            } else 
            {
                enterAttackRangeSignal.Dispatch();
				if (distance <= data.attackRange)
				{
					isInAttackRange = true;
                    if (distance <= 1f)
					{
                        isReachTower = true;
					}
				}
            }
		}

        //Call this every 0.02s
		void FixedUpdate()
		{
            //If game is not over or game speed > 0
            if (!isGameOver || gameSpeed > 0)
            {
                distance = Vector3.Distance(transform.position, data.targetPosition);
                //If reach tower then stop moving
				if (!isReachTower)
				{
                    gameObject.transform.position = Vector3.MoveTowards(transform.localPosition, data.targetPosition, gameSpeed * data.speed * Time.deltaTime);
				}
				//If this enemy is in tower attack range => check whether it can attack tower
				//If this enemy is not in tower attack range then check whether enter tower attack range
				if (isInTowerAttackRange)
				{
                    if (isInAttackRange)
                    {
						timer += Time.deltaTime;
						if (timer >= 0.5f / gameSpeed)
						{
							enemyAttackSignal.Dispatch();
							timer = 0f;
						}
						//Check whether reach tower
						if (distance < 1)
						{
							isReachTower = true;
							gameObject.GetComponentInChildren<Rigidbody>().isKinematic = true;
						}
                    } else
                    {
						if (distance <= data.attackRange)
						{
							isInAttackRange = true;
						}
                    }
				}
				else
				{
					if (distance <= data.towerAttackRange)
					{
                        isInTowerAttackRange = true;
						enterAttackRangeSignal.Dispatch();
					}
				}
            }
		}

		public bool TakeDamage(float damage)
		{
			data.health -= damage;
			if (data.health <= 0)
			{
				isInTowerAttackRange = false;
				return true;
			}
			return false;
		}

        public void UpdateGameSpeed(int gameSpeed)
        {
            this.gameSpeed = gameSpeed;
        }

        public void UpdateIsGameOver(bool isGameOver)
        {
            this.isGameOver = isGameOver;
        }

		EnemyView SetEnemyForm(EnemyType enemyType)
		{
			switch (enemyType)
			{
				case EnemyType.NORMAL:
					{
						DisableAllForm();
						normalForm.SetActive(true);
						break;
					}
				case EnemyType.FAST:
					{
						DisableAllForm();
						fastForm.SetActive(true);
						break;
					}
				case EnemyType.BIG:
					{
						DisableAllForm();
						bigForm.SetActive(true);
						break;
					}
				case EnemyType.STRONG:
					{
						DisableAllForm();
						strongForm.SetActive(true);
						break;
					}
			}
			return this;
		}

		void DisableAllForm()
		{
			normalForm.SetActive(false);
			fastForm.SetActive(false);
			bigForm.SetActive(false);
			strongForm.SetActive(false);
		}
	}
}