using UnityEngine;
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

		public override void Execute()
		{
			switch (label)
			{
				case "Speedx2Button":
					if (gameModel.gameSpeed <= 2)
					{
						gameModel.gameSpeed *= 2;
					}
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
				default:
					break;
			}
		}
	}

}
