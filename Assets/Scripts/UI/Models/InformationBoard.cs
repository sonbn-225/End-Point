using UnityEngine;
using System.Collections;
using strange.extensions.signal.impl;

public class InformationBoard {

	public int Score { get; private set; }

    [Inject]
    public UpdateInformationBoardSignal updateInformationBoardSignal { get; set; }

    public void AddScore(int score) {
        Score += score;
        UpdateInformationBoard();
    }

    public void UpdateInformationBoard()
    {
        updateInformationBoardSignal.Dispatch();
    }
}
