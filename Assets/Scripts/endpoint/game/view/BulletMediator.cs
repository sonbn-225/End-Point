using strange.extensions.mediation.impl;
using UnityEngine;

namespace endpoint.game
{
	public class BulletMediator : Mediator
	{
		[Inject]
        public BulletView view { get; set; }

        [Inject]
        public BulletHitTargetSignal bulletHitTargetSignal { get; set; }

        [Inject]
        public UpdateGameSpeedSignal updateGameSpeedSignal { get; set; }

        [Inject]
        public IGameModel gameModel { get; set; }

		public override void OnRegister()
		{
            view.BulletHitTargetSignal.AddListener(onBulletHitTarget);
            updateGameSpeedSignal.AddListener(onUpdateGameSpeed);
        }

        public override void OnRemove()
        {
            view.BulletHitTargetSignal.RemoveListener(onBulletHitTarget);
            updateGameSpeedSignal.RemoveListener(onUpdateGameSpeed);
            base.OnRemove();
        }

        private void onBulletHitTarget(GameObject go)
        {
            bulletHitTargetSignal.Dispatch(view, go);
        }

        private void onUpdateGameSpeed()
        {
            view.UpdateGameSpeed(gameModel.gameSpeed);
        }
	}
}

