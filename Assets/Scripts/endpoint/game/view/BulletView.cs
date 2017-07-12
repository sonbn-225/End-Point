using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace endpoint.game
{
	public class BulletView : View
	{
		public IBullet data { get; set; }

        internal Signal<GameObject> BulletHitTargetSignal = new Signal<GameObject>();

        public bool isGameOver;
        internal int gameSpeed;

        public void Init(int gameSpeed)
        {
            isGameOver = false;
            this.gameSpeed = gameSpeed;
        }

		private void FixedUpdate()
		{
			transform.position = Vector3.MoveTowards(transform.position, data.targetPosition, gameSpeed * data.speed * Time.deltaTime);

            if (gameObject.transform.position.y <= 0 && gameObject.name.Contains("Tower") || isGameOver)
			{
				Reset();
			}
			else if (Vector3.Distance(data.targetPosition, gameObject.transform.position) < 1f)
			{
				BulletHitTargetSignal.Dispatch(data.targetObject);
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
