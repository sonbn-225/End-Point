using System.Collections;
using System.Collections.Generic;
using endpoint.ui;
using strange.extensions.command.impl;
using UnityEngine;

namespace endpoint.game
{
    public class EndGameCommand : Command 
    {
        [Inject]
        public ISpawner spawner { get; set; }

        [Inject(UIElement.GAMEOVER_PANEL)]
        public GameObject gameOverPanel { get; set; }

        [Inject]
        public IGameModel gameModel { get; set; }

        public override void Execute()
        {
            spawner.Stop();
            gameModel.isGameOver = true;
            gameOverPanel.SetActive(true);
        }
    }
}
