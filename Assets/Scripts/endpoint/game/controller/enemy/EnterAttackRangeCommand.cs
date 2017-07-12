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
        public IEnemyManager enemyManager { get; set; }

        public override void Execute()
        {
            enemy.isInAttackRange = true;
            enemyManager.addEnemy(enemy.gameObject);
        }
	}
}

