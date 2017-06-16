using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;

public class GameStartCommand : Command
{
    [Inject]
    public IGameManager gameManager { get; set; }

    public override void Execute()
    {
        gameManager.InitGround();
        gameManager.InitTower();
        gameManager.InitEnemySpawner();
        gameManager.InitPool();
    }
}
