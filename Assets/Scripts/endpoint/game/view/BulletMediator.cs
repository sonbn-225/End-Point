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

        [Inject]
        public UpdateGameSpeedSignal updateGameSpeedSignal { get; set; }

        [Inject]
        public IGameModel gameModel { get; set; }

        [Inject]
        public GameEndSignal gameEndSignal { get; set; }

		public override void OnRegister()
		{
            View.BulletHitTargetSignal.AddListener(onBulletHit);
            updateGameSpeedSignal.AddListener(onUpdateGameSpeed);
            gameEndSignal.AddListener(onUpdateIsGameOver);
        }

        private void onBulletHit(GameObject go)
        {
            bulletHitSignal.Dispatch(View, go);
        }

        private void onUpdateGameSpeed()
        {
            View.gameSpeed = gameModel.gameSpeed;
        }

        private void onUpdateIsGameOver()
        {
            Debug.Log("GameEnd" + gameModel.isGameOver);
            View.isGameOver = true;
        }
	}
}

