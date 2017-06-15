using UnityEngine;
using strange.extensions.mediation.impl;
using UnityEngine.UI;

public class InformationBoardView : View {
    private Text scoreTextComponent, attackTextComponent, healthTextComponent;
    public GameObject scoreText, attackText, healthText;

    protected override void Awake() {
        base.Awake();
        scoreTextComponent = scoreText.GetComponent<Text>();
        attackTextComponent = attackText.GetComponent<Text>();
        healthTextComponent = healthText.GetComponent<Text>();
    }

    public void SetScore(int newScore) {
        scoreTextComponent.text = "SCORE: " + newScore;
    }

    public void setAttack(float newAttack)
    {
        attackTextComponent.text = "Attack: " + newAttack;
    }

    public void setHealth(float newHealth)
    {
        healthTextComponent.text = "Health: " + newHealth;
    }
}
