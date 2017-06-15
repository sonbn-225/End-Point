using strange.extensions.command.impl;
using UnityEngine;

public class BulletHitEnemyCommand : Command {

    [Inject]
    public InformationBoard informationBoard { get; set; }

	[Inject]
    public float damage { get; set; }

	[Inject]
	public EnemyView enemy { get; set; }

    [Inject]
    public EnemyPools enemyPools { get; set; }

    public override void Execute() {
		enemy.data.health -= damage;
		if (enemy.data.health <= 0) {
            //Destroy enemy
            enemyPools.ResetEnemy(enemyPools.KillEnemy());
			informationBoard.AddScore (enemy.data.score);
		}
    }

}
