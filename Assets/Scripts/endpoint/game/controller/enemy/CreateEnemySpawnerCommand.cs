using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

namespace endpoint.game
{
    public class CreateEnemySpawnerCommand : Command
    {
        [Inject]
        public ISpawner spawner { get; set; }

        public override void Execute()
        {
            spawner.Start();
        }
    }
}
