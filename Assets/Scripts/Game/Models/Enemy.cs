using UnityEngine;
using System.Collections;
using System;

public class Enemy : IEnemy {
	#region IEnemy implementation

    public EnemyType enemyType { get; set; }

	public float speed { get; set; }

	public float health { get; set; }
     
    public float damage { get; set; }

    public int score { get; set; }

	public Vector3 target { get; set; }

    public float distance { get; set; }

    public bool isInAttackQueue { get; set; }

    public float attackRange { get; set; }

    #endregion
}
