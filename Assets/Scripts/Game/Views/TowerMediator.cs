using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using System;
using System.IO;

public class TowerMediator : Mediator {
	[Inject]
	public TowerView View { get; set; }

	[Inject]
	public TowerShootSignal TowerShootSignal { get; set; }

	[Inject]
	public IEnemyManager EnemyManager { get; set; }

    public override void OnRegister() {
        base.OnRegister();
		View.TowerShootSignal.AddListener (OnTowerShoot);
    }

	private void OnTowerShoot(){
        Debug.Log("Tower View");
		TowerShootSignal.Dispatch ();
	}
}
