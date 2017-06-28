using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class EnemyMediator : Mediator {

    [Inject]
    public EnemyView View { get; set; }

    [Inject]
    public EnterAttackRangeSignal enterAttackRangeSignal { get; set; }

    [Inject]
    public EnemyAttackSignal enemyAttackSignal { get; set; }

    public override void OnRegister() {
        base.OnRegister();
        View.enterAttackRangeSignal.AddListener(OnEnterAttackRange);
        View.enemyAttackSignal.AddListener(OnEnemyAttack);
    }

    public void OnEnterAttackRange()
    {
        enterAttackRangeSignal.Dispatch(View);
    }

    public void OnEnemyAttack()
    {
        enemyAttackSignal.Dispatch(View.data.damage);
    }
}
