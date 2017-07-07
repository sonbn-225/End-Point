using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;
using UnityEngine.UI;

namespace endpoint.game
{
	public class GameDebugView : View
	{
        internal enum ScreenState
        {
            IDLE,
            START_LEVEL,
            END_GAME,
            LEVEL_IN_PROGRESS,
        }

        internal Signal startGameSignal = new Signal();
        internal Signal startLevelSignal = new Signal();

        private ScreenState state = ScreenState.IDLE;

        //current level
        private int level;
        //current score
        private int score;

        protected void OnGUI()
        {
            //display the correct UI, based on screenstate

        }

		internal void SetState(ScreenState state)
		{
			this.state = state;
		}

		internal void SetScore(int score)
		{
			this.score = score;
		}

		internal void SetLevel(int level)
		{
			this.level = level;
		}
    }
}

