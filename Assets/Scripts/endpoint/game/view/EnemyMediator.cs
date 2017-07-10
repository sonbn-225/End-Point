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

		public override void OnRegister()
		{
            view.enterAttackRangeSignal.AddListener(onEnterAttackRange);
            view.enemyAttackSignal.AddListener(onEnemyAttack);
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
            fireBulletSignal.Dispatch(gameObject.transform.localPosition, GameObject.FindGameObjectWithTag("Tower"), GameElement.ENEMY_BULLET_POOL);
        }
	}

}
