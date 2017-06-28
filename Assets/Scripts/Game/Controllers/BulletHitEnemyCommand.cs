using strange.extensions.command.impl;
using UnityEngine;

public class BulletHitEnemyCommand : Command {

	[Inject]
	public InformationBoard informationBoard { get; set; }

	[Inject]
    public bool isKillEnemy { get; set; }

	[Inject]
	public EnemyView enemy { get; set; }

    public override void Execute() {
        if (isKillEnemy)
		{
			informationBoard.AddScore(enemy.data.score);
            EnemyPool.Instance.KillEnemy(enemy.id);
            informationBoard.UpdateInformationBoard();
		}
    }

}
