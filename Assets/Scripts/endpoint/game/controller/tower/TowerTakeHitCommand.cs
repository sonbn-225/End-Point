using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using strange.extensions.pool.api;
using UnityEngine;

namespace endpoint.game
{
    public class TowerTakeHitCommand : Command
    {
        [Inject]
        public TowerView towerView { get; set; }

        [Inject]
        public bool isKilled { get; set; }

		[Inject(GameElement.EXPLOSION_POOL)]
		public IPool<GameObject> pool { get; set; }

        [Inject]
        public IGameModel gameModel { get; set; }

        [Inject]
        public ITower towerData { get; set; }

        [Inject]
        public GameOverSignal gameOverSignal { get; set; }

        [Inject]
        public IRoutineRunner routineRunner { get; set; }

        public override void Execute()
        {
            //if (!gameModel.levelInProgress)
            //{
            //    return;
            //}

            if (isKilled)
            {
				GameObject explosionGO = pool.GetInstance();
				explosionGO.AddComponent<ExplosionView>();
				explosionGO.SetActive(true);
				Vector3 pos = towerView.transform.position;
				explosionGO.transform.localPosition = pos;
                explosionGO.transform.localScale = Vector3.one;
                explosionGO.transform.parent = towerView.transform.parent;

                gameOverSignal.Dispatch();
                towerView.gameObject.SetActive(false);
				if (injectionBinder.GetBinding<TowerView>(GameElement.TOWER) != null)
				{
					injectionBinder.Unbind<TowerView>(GameElement.TOWER);
				}
            }
        }
    }
}
