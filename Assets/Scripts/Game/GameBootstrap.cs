using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;

public class GameBootstrap : ContextView {

	private void Awake() {
        context = new GameContext(this);
    }
}
