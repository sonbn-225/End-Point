using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;

namespace endpoint.game
{
	public class GameStartCommand : Command
	{
		[Inject]
        public UpdateLevelSignal updateLevelSignal { get; set; }

        [Inject]
        public GameStartedSignal gameStartedSignal { get; set; }

        [Inject]
        public UpdateInformationSignal updateInformationSignal { get; set; }

		[Inject]
		public UpdateIsGameOverSignal updateIsGameOverSignal { get; set; }

        [Inject]
        public IGameModel gameModel { get; set; }

        [Inject]
        public ITower towerData { get; set; }

        [Inject]
        public IGameConfig gameConfig { get; set; }

        [Inject]
        public IEnemyManager enemyManager { get; set; }

		public override void Execute()
		{
            //Init tower data
            towerData.Init();

            //Reset level and score in the gameModel
            gameModel.Reset();

            //Init enemyManager
            enemyManager.Init();
            //Update value
            updateLevelSignal.Dispatch(gameModel.level);
            updateInformationSignal.Dispatch();
            updateIsGameOverSignal.Dispatch();

            //Begin the game
            gameStartedSignal.Dispatch();
		}
	}
}

