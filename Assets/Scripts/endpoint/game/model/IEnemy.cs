using UnityEngine;
using System.Collections;

namespace endpoint.game
{
	public interface IEnemy
	{
        int level { get; set; }
		EnemyType enemyType { get; set; }

        //base stat
		float speed { get; set; }
		float health { get; set; }
		float damage { get; set; }
		float attackRange { get; set; }
        int score { get; set; }

        //addition data
        Vector3 targetPosition { get; set; }
        float towerAttackRange { get; set; }
	}
}

