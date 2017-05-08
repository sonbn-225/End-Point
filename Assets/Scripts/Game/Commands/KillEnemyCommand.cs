using strange.extensions.command.impl;

public class KillEnemyCommand : Command {

	[Inject]
    public IDestroyable Enemy { get; set; }

    [Inject]
    public Score Score { get; set; }

	[Inject]
	public BulletView bullet { get; set; }

    public override void Execute() {
		if (Enemy.Destroy (bullet.properties.damage)) {
			Score.AddScore(10);
		}
    }

}
