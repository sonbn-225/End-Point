﻿using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;

public class ButtonClickCommand : Command {
    [Inject]
    public string buttonName { get; set; }

    //[Inject]
    //public ITower towerdata { get; set; }

    [Inject]
    public IUIManager UIManager { get; set; }

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
            default:
                break;
        }
    }
}
