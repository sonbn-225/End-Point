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
        public TowerTakeHitSignal destroyTowerSignal { get; set; }

        [Inject]
        public UpdateAttackSpeedSignal updateAttackSpeedSignal { get; set; }
        [Inject]
        public UpdateGameSpeedSignal updateGameSpeedSignal { get; set; }
        [Inject]
        public UpdateIsGameOverSignal updateIsGameOverSignal { get; set; }
        [Inject]
        public UpdateIsExistEnemyInAttackRangeSignal updateIsExistEnemyInAttackRangeSignal { get; set; }

		[Inject]
        public IGameModel gameModel { get; set; }

        [Inject]
        public ITower towerData { get; set; }

        [Inject]
        public IEnemyManager enemyManager { get; set; }

		public override void OnRegister()
		{
            towerData.towerPosition = view.transform.position;
            view.Init(towerData.attackSpeed, gameModel.gameSpeed, gameModel.isGameOver, gameModel.isExistEnemyInAttackRange);
            view.towerShootSignal.AddListener(OnTowerShoot);

            updateAttackSpeedSignal.AddListener(OnUpdateAttackSpeed);
            updateGameSpeedSignal.AddListener(OnUpdateGameSpeed);
            updateIsGameOverSignal.AddListener(OnUpdateIsGameOver);
            updateIsExistEnemyInAttackRangeSignal.AddListener(OnUpdateIsExistEnemyInAttackRange);
		}

        public override void OnRemove()
        {
            view.towerShootSignal.RemoveListener(OnTowerShoot);

            updateAttackSpeedSignal.RemoveListener(OnUpdateAttackSpeed);
            updateGameSpeedSignal.RemoveListener(OnUpdateGameSpeed);
            updateIsGameOverSignal.RemoveListener(OnUpdateIsGameOver);
            updateIsExistEnemyInAttackRangeSignal.RemoveListener(OnUpdateIsExistEnemyInAttackRange);
        }

        void OnTowerShoot()
        {
            GameObject target = enemyManager.getNearestEnemy();
            //Consider to remove this "if"
            if (target != null)
            {
                Vector3 pos = gameObject.transform.position;
				pos.y += 4;
                fireBulletSignal.Dispatch(pos, target, GameElement.TOWER_BULLET_POOL, towerData.damage); 
            }
        }

        void OnUpdateAttackSpeed()
        {
            view.UpdateAttackSpeed(towerData.attackSpeed);
        }

        void OnUpdateGameSpeed()
        {
            view.UpdateGameSpeed(gameModel.gameSpeed);
        }

        void OnUpdateIsGameOver()
        {
            view.UpdateIsGameOver(gameModel.isGameOver);
        }

        void OnUpdateIsExistEnemyInAttackRange()
        {
            view.UpdateIsExistEnemyInAttackRange(gameModel.isExistEnemyInAttackRange);
        }
	}
}


