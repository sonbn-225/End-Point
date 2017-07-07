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
        internal Signal destroyTowerSignal = new Signal();

		public float timer = 0f;
        public int attackSpeed, gameSpeed;
        public bool isGameOver, isExistEnemyInAttackRange;

        public void Init(int attackSpeed, int gameSpeed, bool isGameOver, bool isExistEnemyInAttackRange)
        {
            timer = 0f;
            this.attackSpeed = attackSpeed;
            this.gameSpeed = gameSpeed;
            this.isGameOver = isGameOver;
            this.isExistEnemyInAttackRange = isExistEnemyInAttackRange;
        }

		private void FixedUpdate()
		{
			if (!isGameOver)
			{
                if (isExistEnemyInAttackRange)
                {
                    timer += Time.deltaTime;
                    if (timer >= 1f/(gameSpeed*attackSpeed))
                    {
                        timer = 0f;
                        Attack();
                    }
                }
			} else 
            {
                destroyTowerSignal.Dispatch();
            }
		}

		private void Attack()
		{
            towerShootSignal.Dispatch();
		}
	}

}
