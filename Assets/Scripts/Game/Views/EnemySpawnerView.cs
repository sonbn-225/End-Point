using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using System;

public class EnemySpawnerView : View, ISpawner {

    public readonly Signal SpawnEnemySignal = new Signal();

	private float timer = 0f;

    [Inject]
    public IGameModel gameModel { get; set; }

    private void FixedUpdate() {
		timer += Time.deltaTime;
        if(timer > 1f/gameModel.gameSpeed) {
			timer = 0f;
			SpawnEnemySignal.Dispatch();
		}
	}


    public void SpawnEnemy(Vector3 position) {
        EnemyType enemyType = (EnemyType)UnityEngine.Random.Range(0, 4);
        EnemyView enemy = EnemyPool.Instance.GetPooledEnemy(enemyType);
        if (enemy == null)
        {
            return;
        }
        enemy.transform.position = position;
        enemy.transform.forward = transform.forward;
        enemy.data = new Enemy()
        {
            enemyType = enemyType,
            speed = 2f,
            health = 200f,
            damage = 2f,
            score = 10,
            target = gameModel.towerTransform.position,
            isInAttackQueue = false
        };
        switch (enemyType)
        {
            case EnemyType.NORMAL:
                break;
            case EnemyType.FAST:
                enemy.data.speed *= 2;
                break;
            case EnemyType.BIG:
                enemy.data.health *= 2;
                break;
            case EnemyType.STRONG:
                enemy.data.damage *= 2;
                break;
        }
        enemy.setActive(true);
    }
}
