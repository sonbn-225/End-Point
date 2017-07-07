﻿using strange.extensions.signal.impl;

namespace endpoint 
{
	public class StartSignal : Signal { }

	//Input
	public class GameInputSignal : Signal<int> { }

	//Game
	public class GameStartSignal : Signal { }
	public class GameEndSignal : Signal { }
	public class LevelStartSignal : Signal { }
	public class LevelEndSignal : Signal { }
	public class UpdateScoreSignal : Signal<int> { }
	public class UpdateLevelSignal : Signal<int> { }

    //UI
    public class ButtonClickSignal : Signal<string>{}
}
