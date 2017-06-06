using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class SpawnerView : View, ISpawner {

    public readonly Signal SpawnEnemySignal = new Signal();
	public readonly Signal InitiateTowerSignal = new Signal ();
	public readonly Signal SpawnBulletSignal = new Signal ();


	private float timer = 0f;
	private int EnemyID = 0;

	private TowerView tower;

	private bool isInitTower = false;

	void Start(){
		InitiateTowerSignal.Dispatch ();
	}

	private void Update() {
		timer += Time.deltaTime;
		if(timer > 1f) {
			timer = 0f;
			SpawnEnemySignal.Dispatch();
		}
	}

    public void SpawnEnemy(Vector3 position) {
        EnemyView enemy = EnemyPools.current.GetPooledEnemy();
        if (enemy == null)
        {
            return;
        }
        enemy.transform.position = position;
        enemy.transform.forward = transform.forward;
        enemy.setActive(true);
        enemy.data = new Enemy()
        {
            id = EnemyID,
            speed = 5f,
            health = 100f,
            damage = 2f,
            score = 10,
            target = tower.transform.position,
            isInAttackQueue = false
        };
        EnemyID++;
    }

	public void SpawnBullet(){
		BulletView bullet = Instantiate<BulletView> (Resources.Load<BulletView> ("Bullet"));
		bullet.transform.position = new Vector3 (0, 10, -15);
		bullet.transform.forward = transform.forward;
		bullet.transform.parent = transform.parent;
	}

	public void InitiateTower(){
		Debug.Log ("AHDAD");
		tower = Instantiate<TowerView> (Resources.Load<TowerView> ("Tower"));
		tower.transform.position = new Vector3(0,0,-15);
		tower.transform.forward = transform.forward;
		tower.transform.parent = transform;
        tower.data = new Tower()
        {
            damage = 100f
        };
	}
}
