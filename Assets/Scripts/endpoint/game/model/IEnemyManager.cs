using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace endpoint.game
{
    public interface IEnemyManager
    {
        List<GameObject> enemies { get; set; }
        void Init();
        void addEnemy(GameObject enemy);
        bool removeEnemy(GameObject enemy);
        GameObject getNearestEnemy();
    }
}
