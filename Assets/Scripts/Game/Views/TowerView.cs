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
		BulletView bullet = Instantiate<BulletView> (Resources.Load<BulletView> ("Bullet"));

        bullet.data = new Bullet()
        {
            enemy = EnemyPools.current.GetNearestEnemy().transform.position,
            damage = data.damage,
            speed = 40f
        };
		bullet.transform.SetParent(transform.parent);
		bullet.transform.position = new Vector3(0, 4, -15);
	}
}
