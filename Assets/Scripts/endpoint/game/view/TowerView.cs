﻿using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using System;

namespace endpoint.game
{
	public class TowerView : View
	{
        internal Signal towerShootSignal = new Signal();
        //internal Signal destroyTowerSignal = new Signal();

		public float timer = 0f;
        public int attackSpeed, gameSpeed;
        public bool isGameOver;

        public void Init(int attackSpeed, int gameSpeed, bool isGameOver)
        {
            timer = 0f;
            this.attackSpeed = attackSpeed;
            this.gameSpeed = gameSpeed;
            this.isGameOver = isGameOver;
        }

		private void FixedUpdate()
		{
            if (!isGameOver)
            {
                timer += Time.deltaTime;
                if (timer >= 1f / (gameSpeed * attackSpeed))
                {
                    timer = 0f;
                    Debug.Log("Tower attack");
                    towerShootSignal.Dispatch();
                }
            }
		}
	}

}
