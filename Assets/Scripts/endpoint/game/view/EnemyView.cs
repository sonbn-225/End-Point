using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace endpoint.game
{
	public class EnemyView : View
	{
		public IEnemy data { get; set; }

        //These Signals inform the Mediator that certain events have occurred
        internal Signal enterAttackRangeSignal = new Signal();
        internal Signal enemyAttackSignal = new Signal();

		public Vector3 target { get; set; }

		public float distance { get; set; }

		public bool isInAttackRange { get; set; }

        internal float towerAttackRange { get; set; }

        internal int gameSpeed { get; set; }

        public bool isGameOver;

        public bool isReachTower;

        public void Init(float attackRange, int gameSpeed, Vector3 tower)
		{
            SetEnemyForm(data.enemyType);
            target = tower;
            distance = Vector3.Distance(gameObject.transform.position, target);
            towerAttackRange = attackRange;
            this.gameSpeed = gameSpeed;
            if (distance > towerAttackRange)
            {
                isInAttackRange = false;
            } else 
            {
                enterAttackRangeSignal.Dispatch();
            }
            isReachTower = false;
            isGameOver = false;
		}

		private float timer = 1f;

		public GameObject normalForm, fastForm, bigForm, strongForm;

		private void FixedUpdate()
		{
            if (!isGameOver)
            {
				distance = Vector3.Distance(transform.position, target);
				if (!isReachTower)
				{
					gameObject.transform.position = Vector3.MoveTowards(transform.localPosition, target, gameSpeed * data.speed * Time.deltaTime);
				}
				if (!isInAttackRange)
				{
					if (distance <= towerAttackRange)
					{
						enterAttackRangeSignal.Dispatch();
					}
				}
				else
				{
					//Enemy attack
					if (distance <= data.attackRange)
					{
						timer += Time.deltaTime;
						if (timer >= 0.5f / gameSpeed)
						{
							enemyAttackSignal.Dispatch();
							timer = 0f;
						}
					}
					if (distance < 1)
					{
						isReachTower = true;
						gameObject.GetComponentInChildren<Rigidbody>().isKinematic = true;
					}
				}
            }
		}

		public bool TakeDamage(float damage)
		{
			data.health -= damage;
			if (data.health <= 0)
			{
				isInAttackRange = false;
				return true;
			}
			return false;
		}


		//For enemyPool
		public void setActive(bool value)
		{
			gameObject.SetActive(value);
		}

		public bool activeInHierarchy()
		{
			return gameObject.activeInHierarchy;
		}

		public EnemyView SetEnemyForm(EnemyType enemyType)
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

		private void DisableAllForm()
		{
			normalForm.SetActive(false);
			fastForm.SetActive(false);
			bigForm.SetActive(false);
			strongForm.SetActive(false);
		}
	}
}