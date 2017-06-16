using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class EnemySpawnerView : View, ISpawner {

    public readonly Signal SpawnEnemySignal = new Signal();

	private float timer = 0f;
	private int EnemyID = 0;

    [Inject]
    public IGameModel gameModel { get; set; }

    private void Update() {
		timer += Time.deltaTime;
		if(timer > 1f) {
			timer = 0f;
			SpawnEnemySignal.Dispatch();
		}
	}

    public void SpawnEnemy(Vector3 position) {
        EnemyView enemy = EnemyPools.Instance.GetPooledEnemy();
        if (enemy == null)
        {
            return;
        }
        enemy.transform.position = position;
        enemy.transform.forward = transform.forward;
        enemy.setActive(true);
        enemy.data = new Enemy()
        {
            speed = 5f,
            health = 100f,
            damage = 2f,
            score = 10,
            target = gameModel.towerTransform.position,
            isInAttackQueue = false
        };
        EnemyID++;
    }
}
