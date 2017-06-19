using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

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
            speed = 2f,
            health = 200f,
            damage = 2f,
            score = 10,
            target = gameModel.towerTransform.position,
            isInAttackQueue = false
        };
    }
}
