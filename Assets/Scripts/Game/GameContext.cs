using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;

public class GameContext : MVCSContext {

	public GameContext(GameBootstrap gameView) : base(gameView) {

    }

    protected override void mapBindings() {
        base.mapBindings();

        injectionBinder.Bind<Score>().To<Score>().ToSingleton();

        commandBinder.Bind<SpawnEnemySignal>().To<SpawnEnemyCommand>();
		commandBinder.Bind<InitiateTowerSignal> ().To<InitiateTowerCommand> ();
        commandBinder.Bind<BulletHitEnemySignal>().To<BulletHitEnemyCommand>();
		commandBinder.Bind<TowerShootSignal> ().To<TowerShootCommand> ();

		mediationBinder.Bind<TowerView>().To<TowerMediator>();
        mediationBinder.Bind<BulletView>().To<BulletMediator>();
		mediationBinder.Bind<EnemyView> ().To<EnemyMediator> ();
        mediationBinder.Bind<SpawnerView>().To<SpawnerMediator>();
        mediationBinder.Bind<ScoreView>().To<ScoreMediator>();
        injectionBinder.Bind<ITower>().To<Tower>().ToSingleton();
    }

    protected override void addCoreComponents() {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }
}
