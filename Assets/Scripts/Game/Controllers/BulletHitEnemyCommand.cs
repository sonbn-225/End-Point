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
        Debug.Log("Health: " + enemy.data.health);
		enemy.data.health -= damage;
		if (enemy.data.health <= 0) {
            //Destroy enemy
            Debug.Log("Distance: " + Vector3.Distance(enemy.transform.position, new Vector3(0, 0, -15)) + "Health: " + enemy.data.health);
            EnemyPools.Instance.KillEnemy(enemy.id);
            enemy.data.isInAttackQueue = false;
			informationBoard.AddScore (enemy.data.score);
		}
    }

}
