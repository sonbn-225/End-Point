using System;
using UnityEngine;

namespace endpoint.game
{
    public class GameConfig : IGameConfig
    {
        //PostConstruct methods fire automatically after Construction
        //and after all injections are satisfied. It's a safe place
        //to do things you'd usually sonsider doing in the Constructor.
        [PostConstruct]
        public void PostConstruct()
        {
            TextAsset file = Resources.Load ("gameConfig") as TextAsset;

            var n = SimpleJSON.JSON.Parse (file.text);

            baseEnemyScore = n ["baseEnemyScore"].AsInt;
        }

        #region implement IGameConfig
        public int baseEnemyScore{ get; set; }
        #endregion
    }
}
