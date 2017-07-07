using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

namespace endpoint.game
{
    public class EndGameCommand : Command 
    {
        [Inject]
        public ISpawner spawner { get; set; }

        public override void Execute()
        {
            spawner.Stop();
        }
    }
}
