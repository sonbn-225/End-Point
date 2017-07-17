using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.pool.api;
using strange.extensions.pool.impl;

namespace endpoint.game
{
    public class GameContext : SignalContext
    {

        public GameContext(GameBootstrap gameView) : base(gameView)
        {
            Debug.Log("Game Start");
        }

        protected override void mapBindings()
        {
            base.mapBindings();
            //Injection
            if (Context.firstContext == this)
            {
                injectionBinder.Bind<IGameModel>().To<GameModel>().ToSingleton();
            }

            injectionBinder.Bind<ITower>().To<Tower>().ToSingleton().CrossContext();
            injectionBinder.Bind<ISpawner>().To<EnemySpawner>().ToSingleton();
            injectionBinder.Bind<IGameConfig>().To<GameConfig>().ToSingleton();
            injectionBinder.Bind<IEnemyManager>().To<EnemyManager>().ToSingleton();

			//Pools
			//Pools provide a recycling system that makes the game much more efficient. Instead of destroying instances
			//(missiles/rocks/enemies/explosions) and re-instantiating them -- which is expensive -- we "checkout" the instances
			//from a pool, then return them when done.

			//These bindings setup the necessary pools, each as a Named injection, so we can tell the pools apart.
			injectionBinder.Bind<IPool<GameObject>>().To<Pool<GameObject>>().ToSingleton().ToName(GameElement.ENEMY_POOL);
            injectionBinder.Bind<IPool<GameObject>>().To<Pool<GameObject>>().ToSingleton().ToName(GameElement.ENEMY_BULLET_POOL);
            injectionBinder.Bind<IPool<GameObject>>().To<Pool<GameObject>>().ToSingleton().ToName(GameElement.TOWER_BULLET_POOL);
            injectionBinder.Bind<IPool<GameObject>>().To<Pool<GameObject>>().ToSingleton().ToName(GameElement.EXPLOSION_POOL);

			//Signals
			//When a Signal isn't bound to a Command, it needs to be mapped, just like any other injected instance
			injectionBinder.Bind<GameStartedSignal>().ToSingleton();
            injectionBinder.Bind<LevelStartedSignal>().ToSingleton();

            injectionBinder.Bind<UpdateAttackSpeedSignal>().ToSingleton();
            injectionBinder.Bind<UpdateGameSpeedSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<UpdateIsGameOverSignal>().ToSingleton();
            if (Context.firstContext ==  this)
            {
                injectionBinder.Bind<UpdateLevelSignal>().ToSingleton();
                injectionBinder.Bind<UpdateScoreSignal>().ToSingleton();
                injectionBinder.Bind<UpdateLoginStatusSignal>().ToSingleton();
            }

            //Command
            if (Context.firstContext == this)
            {
                //Standalone
                commandBinder.Bind<StartSignal>().To<GameIndependentStartCommand>().Once();
            } else 
            {
                //Multi-context
                //commandBinder.Bind<StartSignal>().To<GameModuleStartCommand>().Once();
                commandBinder.Bind<StartSignal>().To<GameIndependentStartCommand>().Once();
            }

			//All the Signals/Commands necessary to play the game
			//Note:
			//1. Some of these are marked Pooled().
			//   Pooled Commands are more efficient when called repeatedly, but take up memory.
			//   Mark a Command as pooled if it will be called a lot...as in the main game loop.
			//2. Binding a Signal to a Command automatically maps the signal for injection.
			//   So it's only necessary to explicitly injectionBind Signals if they are NOT
			//   mapped to Commands.
            //Tower
			commandBinder.Bind<CreateTowerSignal>().To<CreateTowerCommand>();
            commandBinder.Bind<DestroyTowerSignal>().To<DestroyTowerCommand>();
            //Enemy
			commandBinder.Bind<CreateEnemySignal>().To<CreateEnemyCommand>().Pooled();
            commandBinder.Bind<DestroyEnemySignal>().To<DestroyEnemyCommand>().Pooled();
            commandBinder.Bind<EnterAttackRangeSignal>().To<EnterAttackRangeCommand>();
            //Bullet
            commandBinder.Bind<FireBulletSignal>().To<FireBulletCommand>().Pooled();
            commandBinder.Bind<DestroyBulletSignal>().To<DestroyBulletCommand>().Pooled();
            commandBinder.Bind<BulletHitSignal>().To<BulletHitCommand>().Pooled();

            commandBinder.Bind<GameStartSignal>().To<GameStartCommand>();
            commandBinder.Bind<GameEndSignal>().To<EndGameCommand>();

            commandBinder.Bind<LevelStartSignal>()
                         .To<CreateGameFieldCommand>()
                         .To<CleanupLevelCommand>()
                         .To<StartLevelCommand>()
                         .InSequence();
            commandBinder.Bind<LevelEndSignal>()
                         .To<CleanupLevelCommand>()
                         .To<LevelEndCommand>()
                         .InSequence();
            commandBinder.Bind<SetupLevelSignal>()
                         .To<SetupLevelCommand>()
                         .To<CreateEnemySpawnerCommand>();

            //Mediation
            mediationBinder.Bind<EnemyView>().To<EnemyMediator>();
            mediationBinder.Bind<BulletView>().To<BulletMediator>();
            mediationBinder.Bind<ExplosionView>().To<ExplosionMediator>();
            mediationBinder.Bind<TowerView>().To<TowerMediator>();
   		}

		protected override void postBindings()
        {
            IPool<GameObject> enemyPool = injectionBinder.GetInstance<IPool<GameObject>>(GameElement.ENEMY_POOL);
            enemyPool.instanceProvider = new ResourceInstanceProvider("Enemy", LayerMask.NameToLayer("Enemy"));
            enemyPool.inflationType = PoolInflationType.INCREMENT;

            IPool<GameObject> enemyBulletPool = injectionBinder.GetInstance<IPool<GameObject>>(GameElement.ENEMY_BULLET_POOL);
            enemyBulletPool.instanceProvider = new ResourceInstanceProvider("EnemyBullet", LayerMask.NameToLayer("Enemy"));
            enemyBulletPool.inflationType = PoolInflationType.INCREMENT;

            IPool<GameObject> towerBulletPool = injectionBinder.GetInstance<IPool<GameObject>>(GameElement.TOWER_BULLET_POOL);
            towerBulletPool.instanceProvider = new ResourceInstanceProvider("TowerBullet", LayerMask.NameToLayer("Bullet"));
            towerBulletPool.inflationType = PoolInflationType.INCREMENT;

            IPool<GameObject> explosionPool = injectionBinder.GetInstance<IPool<GameObject>>(GameElement.EXPLOSION_POOL);
            explosionPool.instanceProvider = new ResourceInstanceProvider("Explosion", LayerMask.NameToLayer("Explosion"));
            explosionPool.inflationType = PoolInflationType.INCREMENT;
            base.postBindings();
        }
	}

}
