using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

namespace endpoint.game
{
    public class TowerMediator : Mediator
    {
        [Inject]
        public TowerView view { get; set; }

		[Inject(GameElement.GAME_FIELD)]
		public GameObject gameField { get; set; }

        //Signal
        [Inject]
        public FireBulletSignal fireBulletSignal { get; set; }

        [Inject]
        public DestroyTowerSignal destroyTowerSignal { get; set; }

        [Inject]
        public UpdateAttackSpeedSignal updateAttackSpeedSignal { get; set; }

        [Inject]
        public UpdateGameSpeedSignal updateGameSpeedSignal { get; set; }

        [Inject]
        public UpdateIsGameOverSignal updateIsGameOverSignal { get; set; }

        [Inject]
        public IGameModel gameModel { get; set; }

        [Inject]
        public ITower towerData { get; set; }

        [Inject]
        public IEnemyManager enemyManager { get; set; }

        [Inject]
        public GameEndSignal gameEndSignal { get; set; }

		public override void OnRegister()
		{
            view.towerShootSignal.AddListener(onTowerShoot);
            view.Init(towerData.attackSpeed, gameModel.gameSpeed, gameModel.isGameOver);
            towerData.towerPosition = view.transform.position;

            updateAttackSpeedSignal.AddListener(onUpdateAttackSpeed);
            updateGameSpeedSignal.AddListener(onUpdateGameSpeed);
            updateIsGameOverSignal.AddListener(onUpdateIsGameOver);
            gameEndSignal.AddListener(onUpdateIsGameOver);
		}

        public override void OnRemove()
        {
            view.towerShootSignal.RemoveListener(onTowerShoot);
            updateAttackSpeedSignal.RemoveListener(onUpdateAttackSpeed);
            updateGameSpeedSignal.RemoveListener(onUpdateGameSpeed);
            updateIsGameOverSignal.RemoveListener(onUpdateIsGameOver);
        }

        private void onTowerShoot()
        {
            GameObject target = enemyManager.getNearestEnemy();
            if (target != null)
            {
				Vector3 pos = gameObject.transform.localPosition;
				pos.y += 4;
                fireBulletSignal.Dispatch(pos, target, GameElement.TOWER_BULLET_POOL, towerData.damage); 
            }
        }

        private void onUpdateAttackSpeed()
        {
            view.attackSpeed = towerData.attackSpeed;
        }

        private void onUpdateGameSpeed()
        {
            view.gameSpeed = gameModel.gameSpeed;
        }

        private void onUpdateIsGameOver()
        {
            view.isGameOver = gameModel.isGameOver;
        }
	}
}


