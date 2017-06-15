using strange.extensions.mediation.impl;
using UnityEngine;

public class SpawnerMediator : Mediator {

    [Inject]
    public SpawnEnemySignal SpawnEnemySignal { get; set; }


    [Inject]
    public SpawnerView View { get; set; }

    public override void OnRegister() {
        base.OnRegister();

        View.SpawnEnemySignal.AddListener(OnSpawnEnemy);
		View.SpawnBulletSignal.AddListener (OnSpawnBullet);
    }

    private void OnSpawnEnemy() {
        SpawnEnemySignal.Dispatch(View, new Vector3(Random.Range(-16, 16), 0, Random.Range(0, 25)));
    }

	private void OnSpawnBullet(){
		
	}
}
