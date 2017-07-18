using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

namespace endpoint.game
{
    public class GamePauseCommand : Command
    {
        [Inject]
        public IGameModel gameModel { get; set; }

        [Inject]
        public UpdateGameSpeedSignal updateGameSpeedSignal { get; set; }

		[Inject]
		public ISpawner spawner { get; set; }

        public override void Execute()
        {
            spawner.Stop();
            gameModel.gameSpeedBackup = gameModel.gameSpeed;
            gameModel.gameSpeed = 0;
            updateGameSpeedSignal.Dispatch();
        }
    }
}