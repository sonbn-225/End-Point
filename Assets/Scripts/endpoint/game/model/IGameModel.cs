using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace endpoint.game
{
	public interface IGameModel
	{
		int score { get; set; }
		int level { get; set; }
		bool levelInProgress { get; set; }

		int gameSpeed { get; set; }
        int gameSpeedBackup { get; set; }
		GameObject tower { get; set; }
		float attackInterval { get; set; }
		bool isGameOver { get; set; }
        bool isExistEnemyInAttackRange { get; set; }

        void Reset();
	}
}

