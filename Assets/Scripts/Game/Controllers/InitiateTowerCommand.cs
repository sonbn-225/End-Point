using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;

public class InitiateTowerCommand : Command {

	[Inject]
	public ISpawner Spawner { get; set; }

	public override void Execute(){
		Spawner.InitiateTower ();
	}
}
