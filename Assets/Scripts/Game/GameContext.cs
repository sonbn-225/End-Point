using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;

public class GameContext : MVCSContext {

	public GameContext(GameBootstrap gameView) : base(gameView) {

    }

    public override void Launch()
    {
        base.Launch();
        GameStartSignal gameStartSignal = (GameStartSignal)injectionBinder.GetInstance<GameStartSignal>();
        gameStartSignal.Dispatch();
    }

    protected override void mapBindings() {
        base.mapBindings();

        injectionBinder.Bind<ITower>().To<Tower>().ToSingleton().CrossContext();
        injectionBinder.Bind<IGameManager>().To<GameManager>().ToSingleton();

        commandBinder.Bind<GameStartSignal>().To<GameStartCommand>().Once();
        commandBinder.Bind<SpawnEnemySignal>().To<SpawnEnemyCommand>();
        commandBinder.Bind<BulletHitEnemySignal>().To<BulletHitEnemyCommand>();
		commandBinder.Bind<TowerShootSignal> ().To<TowerShootCommand> ();

		mediationBinder.Bind<TowerView>().To<TowerMediator>();
        mediationBinder.Bind<BulletView>().To<BulletMediator>();
		mediationBinder.Bind<EnemyView> ().To<EnemyMediator> ();
        mediationBinder.Bind<SpawnerView>().To<SpawnerMediator>();
    }

    protected override void addCoreComponents() {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }
}
