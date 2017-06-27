using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class EnterAttackRangeCommand : Command {

	[Inject]
    public EnemyView enemy { get; set; }

    public override void Execute()
    {
        EnemyPool.Instance.AddEnemyToAttack(enemy);
    }
}
