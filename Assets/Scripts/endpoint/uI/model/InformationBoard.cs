using UnityEngine;
using System.Collections;
using strange.extensions.signal.impl;

namespace endpoint.ui
{
	public class InformationBoard
	{

		public int Score { get; private set; }
		public bool isGameOver { get; set; }

		public void AddScore(int score)
		{
			Score += score;
		}

		public void GameOver()
		{
			isGameOver = true;
		}
	}

}
