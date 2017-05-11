using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class EnemyMediator : Mediator {

    [Inject]
    public EnemyView View { get; set; }

	[Inject]
	public IEnemyManager EnemyManager { get; set; }

    public override void OnRegister() {
        base.OnRegister();
		View.EnterPlayerAttackRangeSignal.AddListener (OnEnterPlayerAttackRange);
    }

	private void OnEnterPlayerAttackRange(){
		EnemyManager.AddEnemy (View);
	}
}
