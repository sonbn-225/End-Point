using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.impl;
using UnityEngine;

namespace endpoint.main
{
	public class MainBootstrap : ContextView
	{
		void Start()
		{
			context = new MainContext(this);
		}
	}
}


