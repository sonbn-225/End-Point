using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace endpoint.game
{
	public class GameModel : IGameModel
	{
		public int score { get; set; }
        public int level { get; set; }
        public bool levelInProgress { get; set; }

		public int gameSpeed { get; set; }
		public Transform towerTransform { get; set; }
		public float attackInterval { get; set; }
		public bool isGameOver { get; set; }
        public bool isExistEnemyInAttackRange { get; set; }

        public void Reset()
        {
            score = 0;
            level = 1;
            gameSpeed = 1;
        }
	}
}

