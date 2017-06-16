using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using System;

public class TowerView : View {
	public readonly Signal TowerShootSignal = new Signal ();

	public float timer = 0f;

    [Inject]
	public ITower data { get; set; }

	[Inject]
	public IGameModel gameModel { get; set; }

    protected override void Start(){
		base.Start ();
		timer = 0f;
	}

	private void FixedUpdate(){
        
		timer += Time.deltaTime;
        if (timer > 1f/(gameModel.gameSpeed*data.attackSpeed) && EnemyPools.Instance.GetNearestEnemy() != null) {
			timer = 0f;
			TowerShootSignal.Dispatch ();
		}
	}

	public void Fire(){
        BulletView bullet = BulletPool.Instance.GetPooledEnemy();
        if (bullet == null)
        {
            return;
        }
        bullet.transform.position = new Vector3(0, 4, -15);
		bullet.transform.forward = transform.forward;
		bullet.setActive(true);
        bullet.data = new Bullet()
        {
            enemy = EnemyPools.Instance.GetNearestEnemy().transform.position,
            damage = data.damage,
            speed = 60f*gameModel.gameSpeed
        };
        Debug.Log("Distance: " + Vector3.Distance(bullet.data.enemy, gameObject.transform.position));
	}
}
