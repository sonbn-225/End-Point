using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

namespace endpoint.game
{
    public class CreateTowerCommand : Command
    {
        [Inject(GameElement.GAME_FIELD)]
        public GameObject gameField { get; set; }

        [Inject]
        public IGameModel gameModel { get; set; }

        public override void Execute()
        {
            if (injectionBinder.GetBinding<TowerView>(GameElement.TOWER) != null)
            {
                injectionBinder.Unbind<TowerView>(GameElement.TOWER);
            }

            GameObject towerStyle = Resources.Load<GameObject>(GameElement.TOWER.ToString());
            towerStyle.transform.localScale = Vector3.one;

            GameObject towerGO = GameObject.Instantiate(towerStyle) as GameObject;
            towerGO.transform.localPosition = Vector3.zero;
            towerGO.layer = LayerMask.NameToLayer("tower");
            towerGO.transform.parent = gameField.transform;
            injectionBinder.Bind<TowerView>().ToValue(towerGO.GetComponent<TowerView>()).ToName(GameElement.TOWER);

            gameModel.levelInProgress = true;
        }
    }
}
