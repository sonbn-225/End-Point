using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace endpoint.game
{
	public class BulletView : View
	{
		public IBullet data { get; set; }

        internal Signal<GameObject> BulletHitEnemySignal = new Signal<GameObject>();

        public bool isGameOver;

        public void Init()
        {
            isGameOver = false;
        }

		private void FixedUpdate()
		{
			transform.position = Vector3.MoveTowards(transform.position, data.targetPosition, data.speed * Time.deltaTime);
			if (Vector3.Distance(data.targetObject.transform.position, gameObject.transform.position) < 1f)
			{
				BulletHitEnemySignal.Dispatch(data.targetObject);
				Reset();
			}
			else if (gameObject.transform.position.y <= 0 || isGameOver)
			{
				Reset();
			}
		}


		public void Reset()
		{
			gameObject.SetActive(false);
		}

		public void setActive(bool value)
		{
			gameObject.SetActive(value);
		}

		public bool activeInHierarchy()
		{
			return gameObject.activeInHierarchy;
		}
	}

}
