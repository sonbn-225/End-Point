using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

public class ButtonMediator : Mediator {
    [Inject]
    public ButtonView View { get; set; }

    [Inject]
    public ButtonClickSignal buttonClickSignal { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();
        View.buttonClickSignal.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        buttonClickSignal.Dispatch(View.buttonName);
    }
}
