﻿using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.impl;
using UnityEngine;
using endpoint.game;

namespace endpoint.main
{
    public class MainContext : SignalContext
	{
		public MainContext(MonoBehaviour contextView) : base(contextView)
		{
		}

		protected override void mapBindings()
		{
			base.mapBindings();

            if (Context.firstContext == this)
            {
                injectionBinder.Bind<IGameModel>().To<GameModel>().ToSingleton().CrossContext();

                injectionBinder.Bind<GameStartSignal>().ToSingleton().CrossContext();
                injectionBinder.Bind<GameInputSignal>().ToSingleton().CrossContext();
                injectionBinder.Bind<GameEndSignal>().ToSingleton().CrossContext();
                injectionBinder.Bind<LevelStartSignal>().ToSingleton().CrossContext();
                injectionBinder.Bind<LevelEndSignal>().ToSingleton().CrossContext();
                injectionBinder.Bind<UpdateScoreSignal>().ToSingleton().CrossContext();
                injectionBinder.Bind<UpdateLevelSignal>().ToSingleton().CrossContext();
            }

            commandBinder.Bind<StartSignal>().To<MainStartCommand>();
		}
	}
}