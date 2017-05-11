using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class EnemySpawnerView : View, IEnemySpawner {

    public readonly Signal SpawnEnemySignal = new Signal();
	private float timer = 0f;
	private float spawnTime = 0f;
	private float spawnSpeed = 1f;
	private int count = 0;
	private float x;
	private float y;
	private float z;

	private int EnemyID = 0;

    public void Spawn() {
        EnemyView enemy = GameObject.Instantiate<EnemyView>(Resources.Load<EnemyView>("Enemy"));
		x = Random.Range(-16, 16);
		y = 0;
		z = Random.Range(0, 25);
		enemy.transform.position = new Vector3(x, y, z);
        enemy.transform.forward = transform.forward;
        enemy.Velocity = enemy.transform.forward * 2;
		enemy.player = GameObject.FindGameObjectWithTag ("Player").transform;
		enemy.ID = EnemyID;
		EnemyID++;
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

}
