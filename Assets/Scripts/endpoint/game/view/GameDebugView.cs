using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

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
	}
}

