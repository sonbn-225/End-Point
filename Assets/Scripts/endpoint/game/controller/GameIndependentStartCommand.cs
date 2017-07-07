using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

namespace endpoint.game
{
    public class GameIndependentStartCommand : Command
    {
        [Inject(ContextKeys.CONTEXT_VIEW)]
        public GameObject contextView { get; set; }

        //Inject to init Routine runner
		[Inject]
		public IRoutineRunner routinerunner { get; set; }

        public override void Execute()
        {
            Debug.Log("GameIndependentStart");
            GameObject go = new GameObject("debug_view");
            go.AddComponent<GameDebugView>();
            go.transform.parent = contextView.transform;
        }
    }
}