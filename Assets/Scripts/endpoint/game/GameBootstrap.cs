using strange.extensions.context.impl;
using UnityEngine;

namespace endpoint.game
{
	public class GameBootstrap : ContextView
	{
        //Init game context
		void Start()
		{
			context = new GameContext(this);
		}
	}
}