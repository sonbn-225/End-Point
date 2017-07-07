using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

namespace endpoint.game
{
    public class SetupLevelCommand : Command
    {
        [Inject(GameElement.GAME_FIELD)]
        public GameObject gameField { get; set; }

        [Inject]
        public IGameModel gameModel { get; set; }

        [Inject]
        public CreateTowerSignal createTowerSignal { get; set; }

        [Inject]
        public IGameConfig gameConfig { get; set; }

        public override void Execute()
        {
            createTowerSignal.Dispatch();
        }
    }
}
