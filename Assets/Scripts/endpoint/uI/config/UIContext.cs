﻿using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.impl;
using UnityEngine;

namespace endpoint.ui
{
    public class UIContext : SignalContext
	{

		public UIContext(MonoBehaviour contextView) : base(contextView)
		{

		}

		protected override void mapBindings()
		{
			base.mapBindings();

            if (Context.firstContext == this)
            {
                injectionBinder.Bind<GameEndSignal>().ToSingleton();
                injectionBinder.Bind<GameInputSignal>().ToSingleton();
                injectionBinder.Bind<GameStartSignal>().ToSingleton();
                injectionBinder.Bind<LevelStartSignal>().ToSingleton();
                injectionBinder.Bind<LevelEndSignal>().ToSingleton();
                injectionBinder.Bind<UpdateLevelSignal>().ToSingleton();
                injectionBinder.Bind<UpdateScoreSignal>().ToSingleton();
            }

			//StartSignal is instantiated and fired in the SignalContext.
			//When it fires, UIStartCommand is Executed.
            commandBinder.Bind<StartSignal>().To<UIStartCommand>();
            commandBinder.Bind<ButtonClickSignal>().To<ButtonClickCommand>();

#if !UNITY_EDITOR && (UNITY_IPHONE || UNITY_ANDROID)

            //This code executes if we're on a mobile device

            mediationBinder.Bind<ButtonView> ().To<ButtonTouchMediator> ();
#else
			//And we'll map the mouse-friendly version of the ButtonMediator
			mediationBinder.Bind<ButtonView>().To<ButtonMediator>();
#endif
			mediationBinder.Bind<InformationBoardView>().To<InformationBoardMediator>();
		}
	}
}

