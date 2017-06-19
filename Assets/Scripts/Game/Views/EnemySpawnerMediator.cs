using strange.extensions.mediation.impl;
using UnityEngine;

public class EnemySpawnerMediator : Mediator {

    [Inject]
    public SpawnEnemySignal SpawnEnemySignal { get; set; }


    [Inject]
    public EnemySpawnerView View { get; set; }

	[Inject]
	public IGameModel gameModel { get; set; }

    [Inject]
    public ITower towerData { get; set; }

    public override void OnRegister() {
        base.OnRegister();

        View.SpawnEnemySignal.AddListener(OnSpawnEnemy);
    }

    private void OnSpawnEnemy() {
        Vector3 pos = new Vector3(Random.Range(-45, 45), 0, Random.Range(-45, 45));
        while (Vector3.Distance(pos, gameModel.towerTransform.position) < towerData.attackRange)
        {
            pos = new Vector3(Random.Range(-45, 45), 0, Random.Range(-45, 45));
        }
        SpawnEnemySignal.Dispatch(View, pos);
    }
}
