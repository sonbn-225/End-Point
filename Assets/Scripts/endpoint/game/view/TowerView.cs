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

		float timer;
        int attackSpeed, gameSpeed;
        bool isGameOver, isExistEnemyInAttackRange;

        public void Init(int attackSpeed, int gameSpeed, bool isGameOver, bool isExistEnemyInAttackRange)
        {
            timer = 0f;
            this.attackSpeed = attackSpeed;
            this.gameSpeed = gameSpeed;
            this.isGameOver = isGameOver;
            this.isExistEnemyInAttackRange = isExistEnemyInAttackRange;
        }

		void FixedUpdate()
		{
            //Need optimize
            if (!isGameOver || gameSpeed > 0 && isExistEnemyInAttackRange)
            {
                timer += Time.deltaTime;
                if (timer >= 1f / (gameSpeed * attackSpeed))
                {
                    timer = 0f;
                    towerShootSignal.Dispatch();
                }
            }
		}

        public void UpdateAttackSpeed(int attackSpeed)
        {
            this.attackSpeed = attackSpeed;
        }

        public void UpdateGameSpeed(int gameSpeed)
        {
            this.gameSpeed = gameSpeed;
        }

        public void UpdateIsGameOver(bool isGameOver)
        {
            this.isGameOver = isGameOver;
        }

        public void UpdateIsExistEnemyInAttackRange(bool isExistEnemyInAttackRange)
        {
            this.isExistEnemyInAttackRange = isExistEnemyInAttackRange;
        }
	}
}
