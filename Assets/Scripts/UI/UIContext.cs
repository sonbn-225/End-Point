using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.impl;
using UnityEngine;

public class UIContext : MVCSContext {
    
    public UIContext (MonoBehaviour contextView) : base(contextView)
    {
        
    }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>();
    }

	public override void Launch()
	{
		base.Launch();
		UIStartSignal uiStartSignal = (UIStartSignal)injectionBinder.GetInstance<UIStartSignal>();
		uiStartSignal.Dispatch();
	}

    protected override void mapBindings()
    {
        base.mapBindings();

        if (Context.firstContext == this)
        {
            
        }
        injectionBinder.Bind<IUIManager>().To<UIManager>().ToSingleton();

        commandBinder.Bind<UIStartSignal>().To<UIStartCommand>().Once();
        commandBinder.Bind<ButtonClickSignal>().To<ButtonClickCommand>();

        mediationBinder.Bind<ButtonView>().To<ButtonMediator>();
        mediationBinder.Bind<ScoreView>().To<ScoreMediator>();
    }
}
