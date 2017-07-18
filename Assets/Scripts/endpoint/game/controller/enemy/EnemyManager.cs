using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace endpoint.game
{
    public class EnemyManager : IEnemyManager
    {
        [Inject]
        public ITower tower { get; set; }

        List<GameObject> enemies { get; set; }

        public void Init()
        {
            enemies = new List<GameObject>();
        }

        public void addEnemy(GameObject enemy)
        {
            enemies.Add(enemy);
        }

        public bool removeEnemy(GameObject enemy)
        {
            return enemies.Remove(enemy);
        }

        public GameObject getNearestEnemy()
        {
            GameObject target = null;
			float minDistance = Mathf.Infinity;
			foreach (GameObject enemy in enemies)
			{
                float currentDistance = Vector3.Distance(enemy.transform.position, tower.towerPosition);
                if (currentDistance < minDistance)
				{
                    target = enemy;
                    minDistance = currentDistance;
				}
			}
            return target;
        }

        public bool isExistEnemyInAttackRange()
        {
            if (enemies.Count > 0)
            {
                return true;
            } 
            return false;
        }
    }
}
