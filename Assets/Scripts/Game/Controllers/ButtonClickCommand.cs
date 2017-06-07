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
                towerdata.damage += 10;
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
