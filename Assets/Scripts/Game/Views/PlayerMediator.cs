using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using System;
using System.IO;

public class PlayerMediator : Mediator {
	[Inject]
	public PlayerView View { get; set; }

	[Inject]
	public PlayerAttackSignal PlayerAttackSignal { get; set; }

	[Inject]
	public IEnemyManager EnemyManager { get; set; }

    public override void OnRegister() {
        base.OnRegister();
		View.PlayerAttackSignal.AddListener (OnPlayerAttack);
    }

	private void OnPlayerAttack(){
		View.target = EnemyManager.KillEnemy ();
		PlayerAttackSignal.Dispatch (View);
	}
}
