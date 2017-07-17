using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using endpoint.game;

namespace endpoint.ui
{
	public class InformationBoardMediator : Mediator
	{

		[Inject]
		public InformationBoardView View { get; set; }

		[Inject]
		public ITower towerData { get; set; }

        [Inject]
        public UpdateScoreSignal updateScoreSignal { get; set; }

        [Inject]
        public UpdateLoginStatusSignal updateLoginStatusSignal { get; set; }

        [Inject]
        public IGameModel gameModel { get; set; }

        [Inject]
        public ISocialService socialService { get; set; }

		public override void OnRegister()
		{
			base.OnRegister();
            updateScoreSignal.AddListener(OnUpdateInformationBoard);
            updateLoginStatusSignal.AddListener(OnUpdateLoginStatus);
            updateLoginStatusSignal.Dispatch();
            updateScoreSignal.Dispatch();
		}

		public override void OnRemove()
		{
			base.OnRemove();
		}

        private void OnUpdateInformationBoard()
        {
            View.SetScore(gameModel.score);
			View.setAttack(Mathf.RoundToInt(towerData.damage));
			View.setAttackSpeed(Mathf.RoundToInt(towerData.attackSpeed));
			View.setCritRate(Mathf.RoundToInt(towerData.critRate));
			View.setCritFactor(Mathf.RoundToInt(towerData.critFactor));
			View.setAttackRange(Mathf.RoundToInt(towerData.attackRange));
			View.setHealth(Mathf.RoundToInt(towerData.health));
			View.setRegenerateHealthSpeed(Mathf.RoundToInt(towerData.regenerateSpeed));
			View.setResourceBonus(Mathf.RoundToInt(towerData.resourceBonus));
		}

        private void OnUpdateLoginStatus()
        {
            View.setLoginPanel(socialService.isLoggedIn());
        }
	}

}
