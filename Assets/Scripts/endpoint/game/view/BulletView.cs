using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace endpoint.game
{
	public class BulletView : View
	{
		public IBullet data { get; set; }

        internal Signal<GameObject> BulletHitTargetSignal = new Signal<GameObject>();

        int gameSpeed;

        public void Init(int gameSpeed)
        {
            this.gameSpeed = gameSpeed;
        }

        //Call this every 0.02s
		void FixedUpdate()
		{
            if (gameSpeed > 0)
            {
				//Move the bullet
                transform.position = Vector3.MoveTowards(transform.position, data.targetPosition, gameSpeed * data.speed * Time.fixedDeltaTime);

				//Check whether bullet reach target
				if (Vector3.Distance(data.targetPosition, gameObject.transform.position) < 1f)
				{
					BulletHitTargetSignal.Dispatch(data.targetObject);
					gameObject.SetActive(false);
				}
				//If Target is destroy before bullet reach then...
            }
            else
            {
                return;
            }
		}

        public void UpdateGameSpeed(int gameSpeed)
        {
            this.gameSpeed = gameSpeed;
        }
	}

}
