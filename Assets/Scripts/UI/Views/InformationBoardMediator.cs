﻿using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class InformationBoardMediator : Mediator {

    [Inject]
    public InformationBoardView View { get; set; }

    [Inject]
    public InformationBoard informationBoard { get; set; }

    [Inject]
    public ITower towerData { get; set; }

    public override void OnRegister() {
        base.OnRegister();
        informationBoard.updateInformationBoardSignal.AddListener(OnUpdateInformationBoard);
        informationBoard.UpdateInformationBoard();
	}

    public override void OnRemove() {
        base.OnRemove();
        informationBoard.updateInformationBoardSignal.RemoveListener(OnUpdateInformationBoard);
    }

    public void OnUpdateInformationBoard() {
		View.SetScore(informationBoard.Score);
        View.setAttack(towerData.damage);
        View.setHealth(towerData.health);
    }

}
