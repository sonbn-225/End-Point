using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

public class UIStartCommand : Command {

    [Inject]
    public IUIManager UIManager { get; set; }
    
    public override void Execute()
    {
        UIManager.InitAttackPanel();
        UIManager.InitDefendPanel();
        UIManager.InitResourcePanel();
        UIManager.InitButtonPanel();
    }
}
