using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

namespace endpoint.ui
{
	public class InformationBoardMediator : Mediator
	{

		[Inject]
		public InformationBoardView View { get; set; }

		[Inject]
		public ITower towerData { get; set; }

		public override void OnRegister()
		{
			base.OnRegister();
		}

		public override void OnRemove()
		{
			base.OnRemove();
		}

		public void OnUpdateInformationBoard()
		{

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
