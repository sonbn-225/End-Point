using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class SpawnerView : View, ISpawner {

    public readonly Signal SpawnEnemySignal = new Signal();
	public readonly Signal InitiateTowerSignal = new Signal ();
	public readonly Signal SpawnBulletSignal = new Signal ();


	private float timer = 0f;
	private float spawnTime = 0f;
	private float spawnSpeed = 1f;
	private int count = 0;
	private float x;
	private float y;
	private float z;

	private int EnemyID = 0;

	private TowerView tower;

	private void Start(){
		InitiateTowerSignal.Dispatch ();
	}

	private void Update() {
		timer += Time.deltaTime;
		spawnTime += Time.deltaTime;
		if(timer > spawnSpeed && count < 10000) {
			timer = 0f;
			count++;
			SpawnEnemySignal.Dispatch();
		}
		if (spawnTime > 5f) {
			spawnTime = 0f;
			spawnSpeed /= 1;
		}
	}

	public EnemyView SpawnEnemy() {
        EnemyView enemy = GameObject.Instantiate<EnemyView>(Resources.Load<EnemyView>("Enemy"));
		x = Random.Range(-16, 16);
		y = 0;
		z = Random.Range(0, 25);
		enemy.transform.position = new Vector3(x, y, z);
        enemy.transform.forward = transform.forward;
		enemy.data.target = tower.transform.position;
		enemy.data.id = EnemyID;
		enemy.data.speed = 5f;
		enemy.data.health = 100f;
		enemy.data.damage = 2f;
		enemy.data.score = 10;
		EnemyID++;
		return enemy;
    }

	public void SpawnBullet(){
		BulletView bullet = GameObject.Instantiate<BulletView> (Resources.Load<BulletView> ("Bullet"));
		bullet.transform.position = new Vector3 (0, 10, -15);
		bullet.transform.forward = transform.forward;
		bullet.transform.parent = transform.parent;
	}

	public void InitiateTower(){
		tower = GameObject.Instantiate<TowerView> (Resources.Load<TowerView> ("Tower"));
		tower.transform.position = new Vector3(0,0,-15);
		tower.transform.forward = transform.forward;
		tower.transform.parent = transform;
	}
}
