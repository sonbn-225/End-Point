using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using DG.Tweening;
using System;
using DG.Tweening.Plugins.Core.PathCore;

public class TurretView : View, ITurret {

    public readonly Signal TurretClickedSignal = new Signal();
	public IPlayer player = new Player ();
	private float timer = 0f;
	private int count = 0;

	protected override void Start(){
		base.Start ();
		timer = 0f;
	}

	private void Update(){
		timer += Time.deltaTime;
		if (GameObject.FindGameObjectWithTag ("Enemy") != null) {
			if (timer > 0.5f && count < 10000) {
				timer = 0f;
				count++;
				TurretClickedSignal.Dispatch ();
			}
		}
	}

    public void Fire() {
        BulletView bullet = GameObject.Instantiate<BulletView>(Resources.Load<BulletView>("Bullet"));
		bullet.properties.damage = player.damage;
		bullet.properties.speed = 2f;
		bullet.properties.enemy = GameObject.FindGameObjectWithTag ("Enemy").transform;
		bullet.transform.SetParent(transform.parent.parent);
		bullet.transform.position = new Vector3(0, 4, -15);
    }

    private void OnMouseDown() {
        transform.DOScaleY(0.8f, 0.05f).SetLoops(2, LoopType.Yoyo);
        TurretClickedSignal.Dispatch();
    }
}
