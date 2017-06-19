using strange.extensions.command.impl;
using UnityEngine;

public class BulletHitEnemyCommand : Command {

	[Inject]
	public InformationBoard informationBoard { get; set; }

	[Inject]
    public float damage { get; set; }

	[Inject]
	public EnemyView enemy { get; set; }

    public override void Execute() {
        enemy.TakeDamage(damage);
        if (enemy.data.health <= 0)
        {
			informationBoard.AddScore(enemy.data.score);
		}
    }

}
