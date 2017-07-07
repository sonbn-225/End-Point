using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace endpoint.game
{
	public class EnemyView : View
	{
		public IEnemy data { get; set; }

		//These Signals inform the Mediator that certain events have occurred
		internal Signal exitScreenSignal = new Signal();
		internal Signal fireWeaponSignal = new Signal();

		[Inject]
		public IGameModel gameModel { get; set; }

		[Inject]
		public ITower towerData { get; set; }

        public Renderer mainRenderer;
		//new
		public int level;
		public void Init(int level, EnemyType type)
		{
			this.level = level;
		}

		public int id { get; set; }

		private float timer = 1f, distance = Mathf.Infinity;

		public GameObject normalForm, fastForm, bigForm, strongForm;

		private void FixedUpdate()
		{
			if (!gameModel.isGameOver)
			{
				gameObject.transform.position = Vector3.MoveTowards(transform.position, data.target, gameModel.gameSpeed * data.speed * Time.deltaTime);
				if (!data.isInAttackQueue)
				{
					distance = Vector3.Distance(transform.position, data.target);
					if (distance <= towerData.attackRange)
					{
						data.isInAttackQueue = true;
					}
				}
				if (distance <= data.attackRange)
				{
					timer += Time.deltaTime;
					if (timer >= 0.5f / gameModel.gameSpeed)
					{
						timer = 0f;
					}
				}
			}

		}

		public bool TakeDamage(float damage)
		{
			data.health -= damage;
			if (data.health <= 0)
			{
				data.isInAttackQueue = false;
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