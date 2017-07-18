using strange.extensions.signal.impl;

namespace endpoint 
{
	public class StartSignal : Signal { }

	//Input
	public class GameInputSignal : Signal<int> { }

	//Game
	public class GameStartSignal : Signal { }
    public class GamePauseSignal : Signal { }
    public class GameResumeSignal : Signal { }
	public class GameOverSignal : Signal { }
	public class LevelStartSignal : Signal { }
	public class LevelEndSignal : Signal { }
	public class UpdateScoreSignal : Signal { }
	public class UpdateLevelSignal : Signal<int> { }

    //UI
    public class ButtonClickSignal : Signal<string>{}
    public class UpdateLoginStatusSignal : Signal{}
}
