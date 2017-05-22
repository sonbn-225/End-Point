using strange.extensions.mediation.impl;

public class SpawnerMediator : Mediator {

    [Inject]
    public SpawnEnemySignal SpawnEnemySignal { get; set; }

	[Inject]
	public InitiateTowerSignal InitiateTowerSignal{ get; set; }

    [Inject]
    public SpawnerView View { get; set; }

    public override void OnRegister() {
        base.OnRegister();

        View.SpawnEnemySignal.AddListener(OnSpawnEnemy);
		View.InitiateTowerSignal.AddListener (OnInitiateTower);
		View.SpawnBulletSignal.AddListener (OnSpawnBullet);
    }

    private void OnSpawnEnemy() {
        SpawnEnemySignal.Dispatch(View);
    }

	private void OnInitiateTower(){
		InitiateTowerSignal.Dispatch (View);
	}

	private void OnSpawnBullet(){
		
	}
}
