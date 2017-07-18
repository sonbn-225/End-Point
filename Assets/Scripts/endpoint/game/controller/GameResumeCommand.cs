using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

namespace endpoint.game
{
    public class GameResumeCommand : Command
    {
        [Inject]
        public IGameModel gameModel { get; set; }

        [Inject]
        public UpdateGameSpeedSignal updateGameSpeedSignal { get; set; }

		[Inject]
		public ISpawner spawner { get; set; }

        public override void Execute()
        {
            spawner.Start();
            gameModel.gameSpeed = gameModel.gameSpeedBackup;
            updateGameSpeedSignal.Dispatch();
        }
    }
}
