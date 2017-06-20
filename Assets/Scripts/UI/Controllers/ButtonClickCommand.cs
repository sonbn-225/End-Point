using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;

public class ButtonClickCommand : Command {
    [Inject]
    public string buttonName { get; set; }

    [Inject]
    public ITower towerdata { get; set; }

    [Inject]
    public IUIManager UIManager { get; set; }

    [Inject]
    public IGameModel gameModel { get; set; }

	[Inject]
	public InformationBoard informationBoard { get; set; }

    public override void Execute()
    {
        switch (buttonName)
        {
            case "AttackButton":
                UIManager.AttackButtonClicked();
                break;
            case "DefendButton":
                UIManager.DefendButtonClicked();
                break;
            case "ResourceButton":
                UIManager.ResourceButtonClicked();
                break;
            case "ClosePanelButton":
                UIManager.ClosePanelButtonClicked();
                break;
            case "Speedx2Button":
                gameModel.gameSpeed *= 2;
                break;
            case "IncreaseDamage":
                towerdata.damage *= 1.1f;
                informationBoard.UpdateInformationBoard();
                break;
			case "IncreaseAttackSpeed":
                towerdata.attackSpeed += 1;
                informationBoard.UpdateInformationBoard();
				break;
            case "IncreaseCritRate":
                towerdata.critRate *= 1.1f;
                informationBoard.UpdateInformationBoard();
				break;
			case "IncreaseCritFactor":
                towerdata.critFactor *= 1.1f;
                informationBoard.UpdateInformationBoard();
				break;
			case "IncreaseAttackRange":
                towerdata.attackRange *= 1.1f;
                informationBoard.UpdateInformationBoard();
				break;
			case "IncreaseHealth":
                towerdata.health *= 1.1f;
                informationBoard.UpdateInformationBoard();
				break;
			case "IncreaseRegenerateHealthSpeed":
                towerdata.regenerateSpeed *= 1.1f;
                informationBoard.UpdateInformationBoard();
				break;
			case "IncreaseResourceBonus":
                towerdata.resourceBonus *= 1.1f;
                Debug.Log("OTHER: " + towerdata.attackSpeed);
                informationBoard.UpdateInformationBoard();
				break;
            default:
                break;
        }
    }
}
