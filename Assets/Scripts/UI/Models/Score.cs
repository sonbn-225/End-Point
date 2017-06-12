using UnityEngine;
using System.Collections;
using strange.extensions.signal.impl;

public class Score {

	public int Amount { get; private set; }
    [Inject]
    public ScoreChangedSignal scoreChangedSignal { get; set; }

    public void AddScore(int amount) {
        Amount += amount;
        scoreChangedSignal.Dispatch();
    }
}
