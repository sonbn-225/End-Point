using UnityEngine;
using strange.extensions.mediation.impl;
using UnityEngine.UI;

namespace endpoint.ui
{
	public class InformationBoardView : View
	{
		private Text scoreText, attackText, healthText, attackSpeedText, critRateText, critFactorText, attackRangeText, regenerateHealthText, resourceBonusText;
		public GameObject score, attack, health, attackSpeed, critRate, critFactor, attackRange, regenerateHealth, resourceBonus, gameOver;

		protected override void Awake()
		{
			base.Awake();
			scoreText = score.GetComponent<Text>();
			attackText = attack.GetComponent<Text>();
			healthText = health.GetComponent<Text>();
			attackSpeedText = attackSpeed.GetComponent<Text>();
			critRateText = critRate.GetComponent<Text>();
			critFactorText = critFactor.GetComponent<Text>();
			attackRangeText = attackRange.GetComponent<Text>();
			regenerateHealthText = regenerateHealth.GetComponent<Text>();
			resourceBonusText = resourceBonus.GetComponent<Text>();
		}

		public void SetScore(int newValue)
		{
			scoreText.text = "SCORE: " + newValue;
		}

		public void setAttack(float newValue)
		{
			attackText.text = "Attack: " + newValue;
		}

		public void setHealth(float newValue)
		{
			healthText.text = "Health: " + newValue;
		}

		public void setAttackSpeed(int newValue)
		{
			attackSpeedText.text = "Attack Speed: " + newValue + " shot/s";
		}

		public void setCritRate(float newValue)
		{
			critRateText.text = "Crit Rate: " + newValue + "%";
		}

		public void setCritFactor(float newValue)
		{
			critFactorText.text = "Crit Factor: " + newValue + "%";
		}

		public void setAttackRange(float newValue)
		{
			attackRangeText.text = "Attack Range: " + newValue + "m";
		}

		public void setRegenerateHealthSpeed(float newValue)
		{
			regenerateHealthText.text = "Regenerate Health Speed :" + newValue + "%/s";
		}

		public void setResourceBonus(float newValue)
		{
			resourceBonusText.text = "Resource Bonus: " + newValue;
		}

		public void setGameOver()
		{
			disableALl();
			gameOver.SetActive(true);
		}

		private void disableALl()
		{
			score.SetActive(false);
			attack.SetActive(false);
			health.SetActive(false);
			attackSpeed.SetActive(false);
			critRate.SetActive(false);
			critFactor.SetActive(false);
			attackRange.SetActive(false);
			regenerateHealth.SetActive(false);
			resourceBonus.SetActive(false);
			gameOver.SetActive(false);
		}
	}

}
