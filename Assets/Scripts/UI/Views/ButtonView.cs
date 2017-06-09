using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class ButtonView : View {
    public Signal buttonClickSignal = new Signal();
    public string buttonName;

	public void ButtonClicked(RectTransform rtClicked)
	{
        buttonName = rtClicked.name;
        buttonClickSignal.Dispatch();
	}
}
