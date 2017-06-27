using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class EnemyPool : MySingleton<EnemyPool>
{
    private const int MAX_ENEMY_POOL_SIZE = 10;

    public List<EnemyView> enemies = new List<EnemyView>();
    public List<EnemyView> enemiesToAttack = new List<EnemyView>();

    public bool willGrow = false;

    float minDistance, curDistance;

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

    public EnemyView GetPooledEnemy(EnemyType enemyType)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i].activeInHierarchy())
            {
                return enemies[i].SetEnemyForm(enemyType);
            }
        }
        if (willGrow)
        {
            EnemyView enemy = Instantiate<EnemyView>(Resources.Load<EnemyView>("Enemy"));
            enemy.transform.SetParent(gameObject.transform);
            enemies.Add(enemy);
            return enemy.SetEnemyForm(enemyType);
        }
        return null;
    }

    public void AddEnemyToAttack(EnemyView enemy)
    {
        enemiesToAttack.Add(enemy);
    }

    public void KillEnemy(int id)
    {
        enemies[id].setActive(false);
        Explode(id);
    }

    public EnemyView GetNearestEnemy()
    {
        int nearestEnemyId = -1;
		foreach (EnemyView enemy in enemiesToAttack)
		{
            if (enemy.data.health > 0)
            {
				curDistance = Vector3.Distance(new Vector3(0, 0, 0), enemy.transform.position);
				if (curDistance < minDistance)
				{
					nearestEnemyId = enemy.id;
					minDistance = curDistance;
					Debug.Log("Enemy Pool:" + enemy.data.health + " ID " + enemy.id + "  " + enemy.GetHashCode());
				}
            }
			
		}
		minDistance = Mathf.Infinity;
        if (nearestEnemyId == -1)
        {
            return null;
        } else 
        {
            return enemies[nearestEnemyId];
        }

    }

    private void Explode(int id)
    {
        GameObject explosion = Instantiate(Resources.Load("Explosion")) as GameObject;
        explosion.transform.position = enemies[id].transform.position;
        Destroy(explosion, 1f);
    }
}