using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using strange.extensions.pool.api;
using UnityEngine;

namespace endpoint.game
{
    public class EnemyTakeHitCommand : Command
    {
        //The specific enemy being destroyed
        [Inject]
        public EnemyView enemyView { get; set; }

        //True if this destruction earns the player point
        //False if it flew offscreen or was cleaned up at end of level
        [Inject]
        public bool isKilled { get; set; }

		//The pool to which we return the enemies
		[Inject(GameElement.ENEMY_POOL)]
		public IPool<GameObject> pool { get; set; }

		//Keeper of score, level
		[Inject]
		public IGameModel gameModel { get; set; }

        [Inject]
        public UpdateScoreSignal updateScoreSignal { get; set; }

        [Inject]
        public IGameConfig gameConfig { get; set; }

        [Inject]
        public IEnemyManager enemyManager { get; set; }

        static Vector3 PARKED_POS = new Vector3(1000f, 0f, 1000f);

        public override void Execute()
        {
            if (isKilled)
            {
                gameModel.score += enemyView.data.score;
                updateScoreSignal.Dispatch();

                //Return instance enemy to pool
				enemyView.gameObject.SetActive(false);
				enemyView.transform.localPosition = PARKED_POS;
				enemyManager.removeEnemy(enemyView.gameObject);
				pool.ReturnInstance(enemyView.gameObject);
            }
        }
    }
}
