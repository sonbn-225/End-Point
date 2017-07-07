using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

namespace endpoint.game
{
    public class StartLevelCommand : Command
    {
        [Inject]
        public IGameModel gameModel { get; set; }

        [Inject]
        public LevelStartedSignal levelStartedSignal { get; set; }

        [Inject]
        public SetupLevelSignal setupLevelSignal { get; set; }

        public override void Execute()
        {
            setupLevelSignal.Dispatch();
            gameModel.levelInProgress = true;
            levelStartedSignal.Dispatch();
        }
    }
}
