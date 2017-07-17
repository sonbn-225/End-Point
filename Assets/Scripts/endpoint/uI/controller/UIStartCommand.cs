using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

namespace endpoint.ui
{
	public class UIStartCommand : Command
	{
        [Inject(UIElement.CANVAS)]
        public GameObject canvas { get; set; }

        [Inject]
        public ISocialService socialService { get; set; }

		public override void Execute()
        {
			GameObject buttonPanel = GameObject.Instantiate(Resources.Load("ButtonPanel")) as GameObject;
			buttonPanel.transform.SetParent(canvas.transform, false);
            injectionBinder.Bind<GameObject>().ToValue(buttonPanel).ToName(UIElement.BUTTON_PANEL);

            GameObject informationBoard = GameObject.Instantiate(Resources.Load("InformationBoard") as GameObject);
			informationBoard.transform.SetParent(canvas.transform, false);
            injectionBinder.Bind<GameObject>().ToValue(informationBoard).ToName(UIElement.INFORMATION_BOARD);
			
            GameObject attackPanel = GameObject.Instantiate(Resources.Load("AttackPanel")) as GameObject;
            attackPanel.transform.SetParent(canvas.transform, false);
			attackPanel.SetActive(false);
            injectionBinder.Bind<GameObject>().ToValue(attackPanel).ToName(UIElement.ATTACK_PANEL);

			GameObject defendPanel = GameObject.Instantiate(Resources.Load("DefendPanel")) as GameObject;
			defendPanel.transform.SetParent(canvas.transform, false);
			defendPanel.SetActive(false);
            injectionBinder.Bind<GameObject>().ToValue(defendPanel).ToName(UIElement.DEFEND_PANEL);

			GameObject resourcePanel = GameObject.Instantiate(Resources.Load("ResourcePanel")) as GameObject;
			resourcePanel.transform.SetParent(canvas.transform, false);
			resourcePanel.SetActive(false);
            injectionBinder.Bind<GameObject>().ToValue(resourcePanel).ToName(UIElement.RESOURCE_PANEL);

            GameObject gameOverPanel = GameObject.Instantiate(Resources.Load("GameOverPanel")) as GameObject;
            gameOverPanel.transform.SetParent(canvas.transform, false);
            gameOverPanel.SetActive(false);
            injectionBinder.Bind<GameObject>().ToValue(gameOverPanel).ToName(UIElement.GAMEOVER_PANEL).CrossContext();
		    
            socialService.Init();
        }
	}
}

