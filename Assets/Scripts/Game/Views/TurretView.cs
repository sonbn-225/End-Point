using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using DG.Tweening;
using System;

public class TurretView : View, ITurret {

    public readonly Signal TurretClickedSignal = new Signal();
	private float timer = 0f;

	protected override void Start(){
		base.Start ();
		timer = 0f;
	}

	private void Update(){
		timer += Time.deltaTime;
		if (timer > 2f && GameObject.FindGameObjectWithTag ("Enemy") != null) {
			timer = 0f;
			TurretClickedSignal.Dispatch ();
		}
	}

    public void Fire() {
        BulletView bullet = GameObject.Instantiate<BulletView>(Resources.Load<BulletView>("Bullet"));
        bullet.transform.SetParent(transform);
		bullet.transform.position = transform.position;
    }

    private void OnMouseDown() {
        transform.DOScaleY(0.8f, 0.05f).SetLoops(2, LoopType.Yoyo);
        TurretClickedSignal.Dispatch();
    }
}
