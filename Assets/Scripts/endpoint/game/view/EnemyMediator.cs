using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

namespace endpoint.game
{
	public class EnemyMediator : Mediator
	{

		[Inject]
        public EnemyView view { get; set; }

        //Havent use?
        [Inject]
        public EnemyTakeHitSignal destroyEnemySignal { get; set; }

        [Inject]
        public FireBulletSignal fireBulletSignal { get; set; }

        [Inject]
        public EnterTowerAttackRangeSignal enterTowerAttackRangeSignal { get; set; }

		[Inject]
		public UpdateGameSpeedSignal updateGameSpeedSignal { get; set; }

		[Inject]
		public UpdateIsGameOverSignal updateIsGameOverSignal { get; set; }

		[Inject]
		public IGameModel gameModel { get; set; }

		public override void OnRegister()
		{
            view.enterAttackRangeSignal.AddListener(OnEnterAttackRange);
            view.enemyAttackSignal.AddListener(OnEnemyAttack);
            updateGameSpeedSignal.AddListener(OnUpdateGameSpeed);
            updateIsGameOverSignal.AddListener(OnUpdateGameOver);
		}

        public override void OnRemove()
        {
            view.enterAttackRangeSignal.RemoveListener(OnEnterAttackRange);
            view.enemyAttackSignal.RemoveListener(OnEnemyAttack);
            updateGameSpeedSignal.RemoveListener(OnUpdateGameSpeed);
            updateIsGameOverSignal.RemoveListener(OnUpdateGameOver);
        }

        void OnEnterAttackRange()
        {
            enterTowerAttackRangeSignal.Dispatch(view);
        }

        void OnEnemyAttack()
        {
            fireBulletSignal.Dispatch(gameObject.transform.position, gameModel.tower, GameElement.ENEMY_BULLET_POOL, view.data.damage);
        }

        void OnUpdateGameSpeed()
		{
            view.UpdateGameSpeed(gameModel.gameSpeed);
		}

        void OnUpdateGameOver()
        {
            view.UpdateIsGameOver(gameModel.isGameOver);
        }
	}

}
