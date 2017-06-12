using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.impl;
using UnityEngine;
using strange.extensions.command.api;
using strange.extensions.command.impl;

public class MainContext : MVCSContext {
    public MainContext (MonoBehaviour contextView) : base (contextView)
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
        MainStartSignal mainStartSignal = (MainStartSignal)injectionBinder.GetInstance<MainStartSignal>();
        mainStartSignal.Dispatch();
    }

    protected override void mapBindings ()
    {
        base.mapBindings();

        injectionBinder.Bind<Score>().To<Score>().ToSingleton().CrossContext();
        injectionBinder.Bind<ScoreChangedSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<IGameModel>().To<GameModel>().ToSingleton().CrossContext();

        commandBinder.Bind<MainStartSignal>().To<MainStartCommand>().Once();

    }
}
