using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

namespace endpoint.game
{
	public class GameModuleStartCommand : Command
	{
        public override void Execute()
        {
            Debug.Log("GameModuleStart");
        }
	}
}
