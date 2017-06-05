using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using System;

public class TowerView : View {
	public readonly Signal TowerShootSignal = new Signal ();

	public float timer = 0f;

	public ITower data { get; set; }

	protected override void Start(){
		base.Start ();
		timer = 0f;
	}

	private void Update(){
        
		timer += Time.deltaTime;
		if (timer > 1f) {
			timer = 0f;
			TowerShootSignal.Dispatch ();
		}
	}

	public void Fire(){
//		BulletView bullet = GameObject.Instantiate<BulletView> (Resources.Load<BulletView> ("Bullet"));
//		bullet.damage = data.damage;
//		bullet.enemy = target.transform.position;
//		bullet.transform.SetParent(transform.parent);
//		bullet.transform.position = new Vector3(0, 4, -15);
	}
}
