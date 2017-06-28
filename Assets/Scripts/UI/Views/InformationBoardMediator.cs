using UnityEngine;
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
        if (informationBoard.isGameOver)
        {
            View.setGameOver();
        } else 
        {
			View.SetScore(Mathf.RoundToInt(informationBoard.Score));
			View.setAttack(Mathf.RoundToInt(towerData.damage));
			View.setAttackSpeed(Mathf.RoundToInt(towerData.attackSpeed));
			View.setCritRate(Mathf.RoundToInt(towerData.critRate));
			View.setCritFactor(Mathf.RoundToInt(towerData.critFactor));
			View.setAttackRange(Mathf.RoundToInt(towerData.attackRange));
			View.setHealth(Mathf.RoundToInt(towerData.health));
			View.setRegenerateHealthSpeed(Mathf.RoundToInt(towerData.regenerateSpeed));
			View.setResourceBonus(Mathf.RoundToInt(towerData.resourceBonus));
        }

    }

}
