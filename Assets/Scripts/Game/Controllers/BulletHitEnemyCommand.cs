﻿using strange.extensions.command.impl;
using UnityEngine;

public class BulletHitEnemyCommand : Command {

    [Inject]
    public Score Score { get; set; }

	[Inject]
    public float damage { get; set; }

	[Inject]
	public EnemyView enemy { get; set; }

    public override void Execute() {
		enemy.data.health -= damage;
		if (enemy.data.health <= 0) {
            //Destroy enemy
            EnemyPools.current.ResetEnemy(EnemyPools.current.KillEnemy());
			Score.AddScore (enemy.data.score);
		}
    }

}
