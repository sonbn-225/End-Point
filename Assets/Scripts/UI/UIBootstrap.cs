using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.impl;
using UnityEngine;

public class UIBootstrap : ContextView {
    private void Awake()
    {
        context = new UIContext(this);
    }
}
