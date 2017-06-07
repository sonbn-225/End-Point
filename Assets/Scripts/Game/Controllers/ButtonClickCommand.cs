using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;

public class ButtonClickCommand : Command {
    [Inject]
    public string buttonName { get; set; }

    [Inject]
    public ITower towerdata { get; set; }
    public override void Execute()
    {
        switch (buttonName)
        {
            case "AttackButton":
                break;
            case "DefendButton":
                towerdata.health += 20;
                break;
            case "ResourceButton":
                break;
            default:
                break;
        }
    }
}
