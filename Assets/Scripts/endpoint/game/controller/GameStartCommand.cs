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
        public UpdateScoreSignal updateScoreSignal { get; set; }

        [Inject]
        public IGameModel gameModel { get; set; }

        [Inject]
        public ITower towerData { get; set; }

        [Inject]
        public IGameConfig gameConfig { get; set; }

		public override void Execute()
		{
            Debug.Log("Game Start Command");
            //Init tower data
            towerData.Init();

            //Reset level and score in the gameModel
            gameModel.Reset();

            //Update value
            updateLevelSignal.Dispatch(gameModel.level);
            updateScoreSignal.Dispatch(gameModel.score);

            //Begin the game
            gameStartedSignal.Dispatch();
		}
	}
}

