using strange.extensions.mediation.impl;

public class BulletMediator : Mediator {
    
    [Inject]
    public BulletView View { get; set; }

    [Inject]
    public BulletHitEnemySignal BulletHitEnemySignal { get; set; }

    public override void OnRegister() {
        base.OnRegister();
		View.BulletHitEnemySignal.AddListener(OnBulletHitEnemy);
    }

	private void OnBulletHitEnemy(EnemyView enemy) {
        View.Destroy();
		BulletHitEnemySignal.Dispatch(View.data.damage, enemy);
    }
}
