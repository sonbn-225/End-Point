using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;

public class EnemyAttackCommand : Command {
    [Inject]
    public float damage { get; set; }

    [Inject]
    public ITower towerData { get; set; }

    [Inject]
    public IGameModel gameModel { get; set; }

    public override void Execute()
    {
        towerData.health -= damage;
        if (towerData.health <= 0)
        {
            gameModel.isGameOver = true;
        }
    }
}
