using UnityEngine;
using strange.extensions.command.impl;

public class SpawnEnemyCommand : Command {

    [Inject]
    public ISpawner EnemySpawner { get; set; }

    [Inject]
    public Vector3 position { get; set; }

    public override void Execute() {
        EnemySpawner.SpawnEnemy(position);
    }

}
