using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

namespace endpoint.ui
{
	public class UIStartCommand : Command
	{
        [Inject(UIElement.CANVAS)]
        public GameObject canvas { get; set; }

		public override void Execute()
        {
			GameObject buttonPanel = GameObject.Instantiate(Resources.Load("ButtonPanel")) as GameObject;
			buttonPanel.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

            GameObject informationBoard = GameObject.Instantiate(Resources.Load("InformationBoard") as GameObject);
			informationBoard.transform.SetParent(canvas.transform, false);
			
            GameObject attackPanel = GameObject.Instantiate(Resources.Load("AttackPanel")) as GameObject;
            attackPanel.transform.SetParent(canvas.transform, false);
			attackPanel.SetActive(false);

			GameObject defendPanel = GameObject.Instantiate(Resources.Load("DefendPanel")) as GameObject;
			defendPanel.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
			defendPanel.SetActive(false);

			GameObject resourcePanel = GameObject.Instantiate(Resources.Load("ResourcePanel")) as GameObject;
			resourcePanel.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
			resourcePanel.SetActive(false);

		}
	}
}

