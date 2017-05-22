using strange.extensions.command.impl;

public class BulletHitEnemyCommand : Command {

    [Inject]
    public Score Score { get; set; }

	[Inject]
	public int damage { get; set; }

	[Inject]
	public EnemyView enemy { get; set; }

    public override void Execute() {
//		if (Enemy.Destroy (bullet.damage)) {
//			Score.AddScore(10);
//		}

		enemy.data.health -= damage;
		if (enemy.data.health <= 0) {
			//Destroy enemy
			Score.AddScore (enemy.data.score);
		}
    }

}
