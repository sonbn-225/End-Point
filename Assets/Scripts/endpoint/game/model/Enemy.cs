using UnityEngine;
using System.Collections;
using System;

namespace endpoint.game
{
	public class Enemy : IEnemy
	{
		#region IEnemy implementation
        public int level { get; set; }
		public EnemyType enemyType { get; set; }

		public float speed { get; set; }
		public float health { get; set; }
		public float damage { get; set; }
		public float attackRange { get; set; }
        public int score { get; set; }

        public Vector3 targetPosition { get; set; }
        public float towerAttackRange { get; set; }
		#endregion
	}
}

