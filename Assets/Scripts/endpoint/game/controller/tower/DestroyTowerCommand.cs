using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

namespace endpoint.game
{
    public class DestroyTowerCommand : Command
    {
        [Inject]
        public TowerView towerView { get; set; }

        [Inject]
        public bool isEndOfLevel { get; set; }

        [Inject]
        public IGameModel gameModel { get; set; }

        [Inject]
        public ITower towerData { get; set; }

        [Inject]
        public GameEndSignal gameEndSignal { get; set; }

        [Inject]
        public CreateTowerSignal createTowerSignal { get; set; }

        [Inject]
        public IRoutineRunner routineRunner { get; set; }

        public override void Execute()
        {
            if (!gameModel.levelInProgress)
            {
                return;
            }

            if (!isEndOfLevel)
            {
                gameModel.levelInProgress = false;

                GameObject explosionProtoType = Resources.Load<GameObject>("Explosion");
                explosionProtoType.transform.localScale = Vector3.one;

                GameObject explosionGO = GameObject.Instantiate(explosionProtoType) as GameObject;
                Vector3 pos = towerView.transform.localPosition;
                explosionGO.transform.localPosition = pos;
                explosionGO.transform.parent = towerView.transform.parent;
            }

            if (towerData.health <= 0)
            {
                gameEndSignal.Dispatch();
            } else
            {
				Retain();
				routineRunner.StartCoroutine(waitThenCreateTower());
            }

            GameObject.Destroy(towerView.gameObject);
            if (injectionBinder.GetBinding<TowerView>(GameElement.TOWER) != null)
            {
                injectionBinder.Unbind<TowerView>(GameElement.TOWER);
            }
        }

        private IEnumerator waitThenCreateTower()
        {
            yield return new WaitForSeconds(2f);
            createTowerSignal.Dispatch();
            Release();
        }
    }
}
