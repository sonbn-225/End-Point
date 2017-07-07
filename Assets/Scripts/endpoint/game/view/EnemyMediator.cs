using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

namespace endpoint.game
{
	public class EnemyMediator : Mediator
	{

		[Inject]
        public EnemyView view { get; set; }

        [Inject]
        public DestroyEnemySignal destroyEnemySignal { get; set; }

        [Inject]
        public FireBulletSignal fireBulletSignal { get; set; }

		public override void OnRegister()
		{
            view.exitScreenSignal.AddListener(onExitScreen);
            view.fireWeaponSignal.AddListener(onFireWeapon);
		}

        public override void OnRemove()
        {
            view.exitScreenSignal.RemoveListener(onExitScreen);
            view.fireWeaponSignal.RemoveListener(onFireWeapon);
        }

        private void onExitScreen()
        {
            destroyEnemySignal.Dispatch(view, false);
        }

        private void onFireWeapon()
        {
            fireBulletSignal.Dispatch(gameObject, GameObject.FindGameObjectWithTag("tower") ,GameElement.ENEMY_BULLET_POOL);
        }
	}

}
