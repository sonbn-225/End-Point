using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using strange.extensions.pool.api;
using UnityEngine;

namespace endpoint.game
{
	public class EnterAttackRangeCommand : Command
	{
		//Enemy entered to attack range
		[Inject]
		public EnemyView enemy { get; set; }

        [Inject]
        public UpdateIsExistEnemyInAttackRangeSignal updateIsExistEnemyInAttackRangeSignal { get; set; }

        [Inject]
        public IEnemyManager enemyManager { get; set; }

        [Inject]
        public IGameModel gameModel { get; set; }

        public override void Execute()
        {
            gameModel.isExistEnemyInAttackRange = true;
            enemyManager.addEnemy(enemy.gameObject);
            updateIsExistEnemyInAttackRangeSignal.Dispatch();
        }
	}
}

