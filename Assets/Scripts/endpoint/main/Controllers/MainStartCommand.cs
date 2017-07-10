using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace endpoint.main
{
	public class MainStartCommand : Command
	{
		[Inject(ContextKeys.CONTEXT_VIEW)]
		public GameObject contextView { get; set; }

		public override void Execute()
		{
			SceneManager.LoadScene("Game", LoadSceneMode.Additive);
			SceneManager.LoadScene("UI", LoadSceneMode.Additive);
		}
	}
}

