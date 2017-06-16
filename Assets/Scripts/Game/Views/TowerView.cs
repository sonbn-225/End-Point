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

    private int id;

    protected override void Start(){
		base.Start ();
		timer = 0f;
	}

	private void FixedUpdate()
    {
		timer += Time.deltaTime;
        if (timer >= 1f/(gameModel.gameSpeed*data.attackSpeed)) 
        {
            id = EnemyPools.Instance.GetNearestEnemy();
            //Debug.Log(timer + "  FIRE::::" + id);
            if (id != -1)
            {
				TowerShootSignal.Dispatch();
            }
            timer = 0f;
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
        EnemyView target = EnemyPools.Instance.enemies[id];
        bullet.data = new Bullet()
        {
            enemy = target.transform.position,
            damage = data.damage,
            speed = 100f*gameModel.gameSpeed
        };
	}
}
