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
        public UpdateIsExistEnemyInAttackRangeSignal updateIsExistEnemyInAttackRangeSignal { get; set; }

        [Inject]
        public IGameModel gameModel { get; set; }

        [Inject]
        public ITower towerData { get; set; }

        private GameObject currentTarget;

		public override void OnRegister()
		{
            view.towerShootSignal.AddListener(onTowerShoot);
            view.destroyTowerSignal.AddListener(onTowerDestroy);
            view.Init(towerData.attackSpeed, gameModel.gameSpeed, gameModel.isGameOver, gameModel.isExistEnemyInAttackRange);

            updateAttackSpeedSignal.AddListener(onUpdateAttackSpeed);
            updateGameSpeedSignal.AddListener(onUpdateGameSpeed);
            updateIsGameOverSignal.AddListener(onUpdateIsGameOver);
            updateIsExistEnemyInAttackRangeSignal.AddListener(onUpdateIsExistEnemyInAttackRange);
		}

        public override void OnRemove()
        {
            view.towerShootSignal.RemoveListener(onTowerShoot);
            view.destroyTowerSignal.RemoveListener(onTowerDestroy);
            updateAttackSpeedSignal.RemoveListener(onUpdateAttackSpeed);
            updateGameSpeedSignal.RemoveListener(onUpdateGameSpeed);
            updateIsGameOverSignal.RemoveListener(onUpdateIsGameOver);
            updateIsExistEnemyInAttackRangeSignal.RemoveListener(onUpdateIsExistEnemyInAttackRange);
        }

        private void onTowerShoot()
        {
            float minDistance = Mathf.Infinity;
            Transform[] enemies = gameField.GetComponentsInChildren<Transform>();
            foreach (Transform enemy in enemies)
            {
                if (enemy.name == "Enemy (clone)")
                {
                    if (Vector3.Distance(enemy.transform.localPosition, view.transform.localPosition) < minDistance)
                    {
                        currentTarget = enemy.gameObject;
                    }
                }
            }
            fireBulletSignal.Dispatch(gameObject, currentTarget, GameElement.TOWER_BULLET_POOL);
            currentTarget = null;
        }

        private void onTowerDestroy()
        {
            destroyTowerSignal.Dispatch(view, false);
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

        private void onUpdateIsExistEnemyInAttackRange()
        {
            view.isExistEnemyInAttackRange = gameModel.isExistEnemyInAttackRange;
        }
	}
}


