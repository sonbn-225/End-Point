using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPools : MonoBehaviour 
{
    public static EnemyPools current;
	private const int MAX_POOL_SIZE = 10;
	public List<EnemyView> enemies = new List<EnemyView>();
    public Queue<EnemyView> enemiesToAttack = new Queue<EnemyView>();

	public bool willGrow = false;
    private float attackRange = 10f;

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

	public void AddEnemyToAttack(EnemyView enemy)
	{
		enemiesToAttack.Enqueue(enemy);
	}

	public EnemyView KillEnemy()
	{
		return (EnemyView)enemiesToAttack.Dequeue();
	}

	public EnemyView GetNearestEnemy()
	{
        if (enemiesToAttack.Count == 0)
        {
            return null;
        } else {
            return (EnemyView)enemiesToAttack.Peek();
        }
	}

    public void ResetEnemy(EnemyView enemy)
    {
        enemy.setActive(false);
    }

    private void Update()
    {
		for (int i = 0; i < enemies.Count; i++)
		{
			if (enemies[i].activeInHierarchy())
			{
                if (!enemies[i].data.isInAttackQueue)
                {
                    if (Vector3.Distance(enemies[i].transform.position, enemies[i].data.target) <= attackRange)
                    {
						enemies[i].data.isInAttackQueue = true;
                        AddEnemyToAttack(enemies[i]);
					}
                }
			}
		}
    }
}