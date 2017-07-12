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

        [Inject]
        public LevelStartSignal levelStartSignal { get; set; }

        [Inject]
        public GameStartSignal gameStartSignal { get; set; }

        public override void Execute()
        {
            gameStartSignal.Dispatch();
            levelStartSignal.Dispatch();
        }
    }
}