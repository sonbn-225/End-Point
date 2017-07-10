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

        public IEnemy GetEnemyData(int level, EnemyType type)
        {
            TextAsset file = Resources.Load("enemyData" + level) as TextAsset;
            var n = SimpleJSON.JSON.Parse(file.text);
            IEnemy enemy = new Enemy();
            enemy.level = level;
            enemy.enemyType = type;

            enemy.speed = n["speed"].AsFloat;
            enemy.health = n["health"].AsFloat;
            enemy.damage = n["damage"].AsFloat;
            enemy.attackRange = n["attackRange"].AsFloat;
            enemy.score = n["score"].AsInt;
            switch (type)
            {
                case EnemyType.BIG:
                    enemy.health *= 2;
                    break;
                case EnemyType.FAST:
                    enemy.speed *= 2;
                    break;
                case EnemyType.STRONG:
                    enemy.damage *= 2;
                    break;
            }
            return enemy;
        }
    }
}
