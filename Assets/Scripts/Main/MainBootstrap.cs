using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.impl;
using UnityEngine;

public class MainBootstrap : ContextView {
    private void Awake()
    {
        context = new MainContext(this);
    }
}
