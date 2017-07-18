﻿using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;
using endpoint.game;

namespace endpoint.ui
{
	public class ButtonClickCommand : Command
	{
		[Inject]
        public string label { get; set; }

		[Inject]
		public ITower towerdata { get; set; }

		[Inject]
		public IGameModel gameModel { get; set; }

        [Inject]
        public UpdateGameSpeedSignal updateGameSpeedSignal { get; set; }

		[Inject]
		public GamePauseSignal gamePauseSignal { get; set; }

        [Inject(UIElement.ATTACK_PANEL)]
        public GameObject attackPanel { get; set; }

        [Inject(UIElement.DEFEND_PANEL)]
        public GameObject defendPanel { get; set; }

        [Inject(UIElement.RESOURCE_PANEL)]
        public GameObject resourcePanel { get; set; }

        [Inject(UIElement.GAMEOVER_PANEL)]
        public GameObject gameOverPanel { get; set; }

		[Inject]
		public GameStartSignal gameStartSignal { get; set; }

		[Inject]
		public LevelStartSignal levelStartSignal { get; set; }

        [Inject]
        public ISocialService socialService { get; set; }

		public override void Execute()
		{
			switch (label)
			{
				case "Speedx2Button":
					if (gameModel.gameSpeed <= 2)
					{
						gameModel.gameSpeed *= 2;
                        updateGameSpeedSignal.Dispatch();
					}
					break;
                case "AttackButton":
                    disableAllPanel();
                    attackPanel.gameObject.SetActive(true);
                    break;
				case "DefendButton":
					disableAllPanel();
					defendPanel.gameObject.SetActive(true);
					break;
				case "ResourceButton":
					disableAllPanel();
					resourcePanel.gameObject.SetActive(true);
					break;
                case "ClosePanelButton":
                    disableAllPanel();
                    break;
				case "IncreaseDamage":
					towerdata.damage *= 1.1f;
					break;
				case "IncreaseAttackSpeed":
					towerdata.attackSpeed += 1;
					gameModel.attackInterval = 1f / (gameModel.gameSpeed * towerdata.attackSpeed);
					break;
				case "IncreaseCritRate":
					towerdata.critRate *= 1.1f;
					break;
				case "IncreaseCritFactor":
					towerdata.critFactor *= 1.1f;
					break;
				case "IncreaseAttackRange":
					towerdata.attackRange *= 1.1f;
					break;
				case "IncreaseHealth":
					towerdata.health *= 1.1f;
					break;
				case "IncreaseRegenerateHealthSpeed":
					towerdata.regenerateSpeed *= 1.1f;
					break;
				case "IncreaseResourceBonus":
					towerdata.resourceBonus *= 1.1f;
					break;
                case "Restart":
                    gameOverPanel.SetActive(false);
                    gameStartSignal.Dispatch();
                    levelStartSignal.Dispatch();
                    break;
                case "FacebookLoginButton":
                    gamePauseSignal.Dispatch();
                    socialService.OnFacebookLoginClick();
                    break;
				default:
					break;
			}
		}

        private void disableAllPanel()
        {
            attackPanel.gameObject.SetActive(false);
            defendPanel.gameObject.SetActive(false);
            resourcePanel.gameObject.SetActive(false);
        }
	}

}
