using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

namespace endpoint.game
{
    public class LevelEndCommand : Command
    {
        [Inject]
        public IGameModel gameModel { get; set; }

        [Inject]
        public UpdateLevelSignal updateLevelSignal { get; set; }

        public override void Execute()
        {
            if (gameModel.levelInProgress)
            {
                gameModel.levelInProgress = false;
                gameModel.level++;
                updateLevelSignal.Dispatch(gameModel.level);
            }
        }
    }
}