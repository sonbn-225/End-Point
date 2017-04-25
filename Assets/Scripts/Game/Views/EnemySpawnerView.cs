using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class EnemySpawnerView : View, IEnemySpawner {

    public readonly Signal SpawnEnemySignal = new Signal();
	private float timer = 0f;

    public void Spawn() {
        EnemyView enemy = GameObject.Instantiate<EnemyView>(Resources.Load<EnemyView>("Enemy"));

        enemy.transform.position = transform.position;
        enemy.transform.forward = transform.forward;
        enemy.Velocity = enemy.transform.forward * 2;
    }

    private void Update() {
		timer += Time.deltaTime;
		if(timer > 2f) {
			timer = 0f;
            SpawnEnemySignal.Dispatch();
        }
    }

}
