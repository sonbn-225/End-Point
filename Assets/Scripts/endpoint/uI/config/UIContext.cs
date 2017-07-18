using System.Collections;
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
                injectionBinder.Bind<GameStartSignal>().ToSingleton();
                injectionBinder.Bind<LevelStartSignal>().ToSingleton();
                injectionBinder.Bind<LevelEndSignal>().ToSingleton();
                injectionBinder.Bind<UpdateLevelSignal>().ToSingleton();
                injectionBinder.Bind<UpdateScoreSignal>().ToSingleton();
                injectionBinder.Bind<UpdateLoginStatusSignal>().ToSingleton();
                injectionBinder.Bind<ITower>().To<Tower>().ToSingleton();
            }

			if (injectionBinder.GetBinding<GameObject>(UIElement.CANVAS) == null)
			{
				GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
				injectionBinder.Bind<GameObject>().ToValue(canvas).ToName(UIElement.CANVAS);
			}

            injectionBinder.Bind<ISocialService>().To<SocialService>().ToSingleton();

			//StartSignal is instantiated and fired in the SignalContext.
			//When it fires, UIStartCommand is Executed.
            commandBinder.Bind<StartSignal>().
                         To<UIStartCommand>();
            commandBinder.Bind<ButtonClickSignal>().To<ButtonClickCommand>();

			mediationBinder.Bind<ButtonView>().To<ButtonMediator>();
			mediationBinder.Bind<InformationBoardView>().To<InformationBoardMediator>();
		}
	}
}

