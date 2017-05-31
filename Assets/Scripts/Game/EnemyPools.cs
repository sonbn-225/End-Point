using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPools : MonoBehaviour 
{
    public static EnemyPools current;
	private const int MAX_POOL_SIZE = 10;
	public List<EnemyView> enemies = new List<EnemyView>();
    public bool willGrow = true;

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        enemies = new List<EnemyView>();
        for (int i = 0; i < MAX_POOL_SIZE; i++)
        {
            EnemyView enemy = Instantiate<EnemyView>(Resources.Load<EnemyView>("Enemy"));
            enemy.setActive(false);
            enemies.Add(enemy);
        }
    }

    public EnemyView GetPooledEnemy()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].activeInHierarchy())
            {
                return enemies[i];
            }
        }
        if (willGrow)
        {
            EnemyView enemy = Instantiate<EnemyView>(Resources.Load<EnemyView>("Enemy"));
            enemies.Add(enemy);
            return enemy;
        }
        return null;
    }

 //   public void create(EnemyView enemy){
	//	for (int i = 0; i < enemies.Count; i++) {
	//		if (enemies[i].data != null){
				
	//		}
	//	}
	//	enemy.data.speed = 5f;
	//	enemy.data.health = 100f;
	//	enemy.data.damage = 2f;
	//	enemy.data.score = 10;
	//	enemies.Add (enemy);
	//}
}