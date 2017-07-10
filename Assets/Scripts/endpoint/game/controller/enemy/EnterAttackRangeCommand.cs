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

        public override void Execute()
        {
            enemy.isInAttackRange = true;
            GameObject.FindGameObjectWithTag("Tower").GetComponent<TowerView>().isExistEnemyInAttackRange = true;
        }
	}
}

