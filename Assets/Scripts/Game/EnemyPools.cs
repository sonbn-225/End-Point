using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPools : MySingleton<EnemyPools> 
{
    private const int MAX_ENEMY_POOL_SIZE = 10;
	public List<EnemyView> enemies = new List<EnemyView>();

    public bool willGrow = false;

	private float minDistance, curDistance;

    [Inject]
    public ITower towerData { get; set; }

    [Inject]
    public IGameModel gameModel { get; set; }

    protected void Start()
    {
        minDistance = Mathf.Infinity;
        enemies = new List<EnemyView>();
        for (int i = 0; i < MAX_ENEMY_POOL_SIZE; i++)
        {
            EnemyView enemy = Instantiate<EnemyView>(Resources.Load<EnemyView>("Enemy"));
            enemy.setActive(false);
            enemy.transform.SetParent(gameObject.transform);
            enemy.id = i;
            enemies.Add(enemy);
        }
    }

    public EnemyView GetPooledEnemy()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i].activeInHierarchy())
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

	public void KillEnemy(int id)
	{
		enemies[id].setActive(false);
        Explore(id);
	}

	public int GetNearestEnemy()
	{
        int nearestEnemyID = -1;
        foreach (EnemyView enemy in enemies)
        {
            if (enemy.activeInHierarchy())
            {
				if (enemy.data.isInAttackQueue)
				{
					curDistance = Vector3.Distance(new Vector3(0, 0, 0), enemy.transform.position);
					if (curDistance < minDistance)
					{
						nearestEnemyID = enemy.id;
						minDistance = curDistance;
					}
				}
            }
        }
        minDistance = Mathf.Infinity;
        return nearestEnemyID;
	}

    private void Explore(int id)
    {
        
		GameObject explosion = Instantiate(Resources.Load("Explosion")) as GameObject;
		explosion.transform.position = enemies[id].transform.position;
		explosion.transform.parent = enemies[id].transform.parent;
        Destroy(explosion, 1f);
    }
}