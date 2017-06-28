using UnityEngine;
using System.Collections;
using strange.extensions.signal.impl;

public class InformationBoard {

	public int Score { get; private set; }
    public bool isGameOver { get; set; }

    [Inject]
    public UpdateInformationBoardSignal updateInformationBoardSignal { get; set; }

    public void AddScore(int score) {
        Score += score;
    }

    public void GameOver()
    {
        isGameOver = true;
    }

    public void UpdateInformationBoard()
    {
        updateInformationBoardSignal.Dispatch();
    }
}
