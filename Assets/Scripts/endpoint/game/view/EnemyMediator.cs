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

        [Inject]
        public EnterAttackRangeSignal enterAttackRangeSignal { get; set; }

		[Inject]
		public UpdateGameSpeedSignal updateGameSpeedSignal { get; set; }

		[Inject]
		public UpdateIsGameOverSignal updateIsGameOverSignal { get; set; }

        [Inject]
        public GameEndSignal gameEndSignal { get; set; }

		[Inject]
		public IGameModel gameModel { get; set; }

		public override void OnRegister()
		{
            view.enterAttackRangeSignal.AddListener(onEnterAttackRange);
            view.enemyAttackSignal.AddListener(onEnemyAttack);
            updateGameSpeedSignal.AddListener(onUpdateGameSpeed);
            gameEndSignal.AddListener(onUpdateGameEnd);
            updateIsGameOverSignal.AddListener(onUpdateGameEnd);
		}

        public override void OnRemove()
        {
            view.enterAttackRangeSignal.RemoveListener(onEnterAttackRange);
            view.enemyAttackSignal.RemoveListener(onEnemyAttack);
        }

        private void onEnterAttackRange()
        {
            enterAttackRangeSignal.Dispatch(view);
        }

        private void onEnemyAttack()
        {
            fireBulletSignal.Dispatch(gameObject.transform.position, gameModel.tower, GameElement.ENEMY_BULLET_POOL, view.data.damage);
        }

		private void onUpdateGameSpeed()
		{
			view.gameSpeed = gameModel.gameSpeed;
		}

        private void onUpdateGameEnd()
        {
            
            view.isGameOver = true;
        }
	}

}
