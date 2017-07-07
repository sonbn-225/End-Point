using System.Collections;
using System.Collections.Generic;
using strange.extensions.context.impl;
using UnityEngine;

namespace endpoint.ui
{
	public class UIBootstrap : ContextView
	{
		void Start()
		{
			context = new UIContext(this);
		}
	}
}

