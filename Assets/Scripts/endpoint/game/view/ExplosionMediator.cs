using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using strange.extensions.pool.api;
using UnityEngine;

namespace endpoint.game
{
    public class ExplosionMediator : Mediator
    {
        [Inject]
        public ExplosionView view { get; set; }

        [Inject(GameElement.EXPLOSION_POOL)]
		public IPool<GameObject> pool { get; set; }

		private static Vector3 PARKED_POS = new Vector3(1000f, 0f, 1000f);

        public override void OnRegister()
        {
            view.animationCompleteSignal.AddListener(onComplete);
        }

        private void onComplete()
        {
            view.gameObject.SetActive(false);
            pool.ReturnInstance(view.gameObject);
        }
    }
}
