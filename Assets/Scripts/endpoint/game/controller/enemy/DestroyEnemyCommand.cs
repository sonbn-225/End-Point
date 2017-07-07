using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using strange.extensions.pool.api;
using UnityEngine;

namespace endpoint.game
{
    public class DestroyEnemyCommand : Command
    {
        //The pool to which we return the enemies
        [Inject(GameElement.ENEMY_POOL)]
        public IPool<GameObject> pool { get; set; }

        //Keeper of score, level
        [Inject]
        public IGameModel gameModel { get; set; }

        //The specific enemy being destroyed
        [Inject]
        public EnemyView enemyView { get; set; }

        //True if this destruction earns the player point
        //False if it flew offscreen or was cleaned up at end of level
        [Inject]
        public bool isPointEarning { get; set; }

        [Inject]
        public UpdateScoreSignal updateScoreSignal { get; set; }

        [Inject]
        public IGameConfig gameConfig { get; set; }

        private static Vector3 PARKED_POS = new Vector3(1000f, 0f, 1000f);

        public override void Execute()
        {
            if (isPointEarning)
            {
                int level = enemyView.level;
                gameModel.score += gameConfig.baseEnemyScore * level;
                updateScoreSignal.Dispatch(gameModel.score);
            }

            enemyView.GetComponent<Rigidbody>().velocity = Vector3.zero;
            enemyView.gameObject.SetActive(false);

            enemyView.transform.localPosition = PARKED_POS;

            pool.ReturnInstance(enemyView.gameObject);
        }
    }
}
