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
                towerdata.damage *= 1.2f;
                informationBoard.UpdateInformationBoard();
                break;
			case "IncreaseAttackSpeed":
				break;
            case "IncreaseCritRate":
				break;
			case "IncreaseCritFactor":
				break;
			case "IncreaseAttackRange":
				break;
			case "IncreaseHealth":
                towerdata.health *= 1.2f;
                informationBoard.UpdateInformationBoard();
				break;
			case "IncreaseSpeed":
				break;
			case "IncreaseResourceBonus":
				break;
            default:
                break;
        }
    }
}
