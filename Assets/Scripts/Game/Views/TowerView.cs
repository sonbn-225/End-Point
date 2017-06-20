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

    private EnemyView target;

	private void FixedUpdate()
    {
		timer += Time.deltaTime;
        if (timer >= 1f/(gameModel.gameSpeed*data.attackSpeed)) 
        {
            target = EnemyPools.Instance.GetNearestEnemy();
            //Debug.Log(timer + "  FIRE::::" + id);
            if (target != null)
            {
				TowerShootSignal.Dispatch();
            }
            timer = 0f;
		}
	}

	public void Fire(){
        BulletView bullet = BulletPool.Instance.GetPooledBullet();
        if (bullet == null)
        {
            return;
        }
        bullet.transform.position = new Vector3(0, 4, 0);
		bullet.transform.forward = transform.forward;
		bullet.setActive(true);
        bullet.data = new Bullet()
        {
            enemy = target,
            damage = data.damage,
            speed = 50f*gameModel.gameSpeed
        };
	}
}
