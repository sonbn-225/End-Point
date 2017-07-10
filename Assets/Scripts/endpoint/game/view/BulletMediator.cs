using strange.extensions.mediation.impl;
using UnityEngine;

namespace endpoint.game
{
	public class BulletMediator : Mediator
	{
		[Inject]
		public BulletView View { get; set; }

        [Inject]
        public BulletHitSignal bulletHitSignal { get; set; }

		public override void OnRegister()
		{
            View.BulletHitEnemySignal.AddListener(onBulletHit);
        }

        private void onBulletHit(GameObject go)
        {
            bulletHitSignal.Dispatch(View, go);
        }
	}
}

