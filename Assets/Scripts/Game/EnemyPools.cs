using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPools : MySingleton<EnemyPools> 
{
    private const int MAX_ENEMY_POOL_SIZE = 10;
	public List<EnemyView> enemies = new List<EnemyView>();
    public Queue enemiesToAttack = new Queue();

    public bool willGrow = false;

    [Inject]
    public ITower towerData { get; set; }

    protected void Start()
    {
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

	public void AddEnemyToAttack(int id)
	{
        if (enemies[id].data.isInAttackQueue)
        {
            enemiesToAttack.Enqueue(id);
        }
	}

	public void KillEnemy()
	{
        int id = (int)enemiesToAttack.Dequeue();
        enemies[id].data.isInAttackQueue = false;
		enemies[id].setActive(false);
	}

	public EnemyView GetNearestEnemy()
	{
        if (enemiesToAttack.Count == 0)
        {
            return null;
        } else {
            return enemies[(int)enemiesToAttack.Peek()];
        }
	}
}