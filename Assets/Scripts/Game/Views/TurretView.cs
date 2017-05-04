using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using DG.Tweening;
using System;

public class TurretView : View, ITurret {

    public readonly Signal TurretClickedSignal = new Signal();
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
        bullet.transform.SetParent(transform);
		bullet.transform.position = new Vector3(0, 4, -15);
    }

    private void OnMouseDown() {
        transform.DOScaleY(0.8f, 0.05f).SetLoops(2, LoopType.Yoyo);
        TurretClickedSignal.Dispatch();
    }
}
