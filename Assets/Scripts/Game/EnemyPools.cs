using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyPools : MySingleton<EnemyPools> 
{
    private const int MAX_ENEMY_POOL_SIZE = 10;
	public List<EnemyView> enemiesNormal = new List<EnemyView>();
    public List<EnemyView> enemiesFast = new List<EnemyView>();
    public List<EnemyView> enemiesBig = new List<EnemyView>();
    public List<EnemyView> enemiesStrong = new List<EnemyView>();


    public bool willGrow = false;

	private float minDistance, curDistance;

    [Inject]
    public ITower towerData { get; set; }

    [Inject]
    public IGameModel gameModel { get; set; }

    protected void Start()
    {
        minDistance = Mathf.Infinity;
        enemiesNormal = new List<EnemyView>();
        for (int i = 0; i < MAX_ENEMY_POOL_SIZE; i++)
        {
            EnemyView enemyNormal = Instantiate<EnemyView>(Resources.Load<EnemyView>("EnemyNormal"));
            enemyNormal.setActive(false);
            enemyNormal.transform.SetParent(gameObject.transform);
            enemyNormal.id = i;
            enemiesNormal.Add(enemyNormal);

            EnemyView enemyFast = Instantiate<EnemyView>(Resources.Load<EnemyView>("EnemyFast"));
            enemyFast.setActive(false);
            enemyFast.transform.SetParent(gameObject.transform);
            enemyFast.id = i;
            enemiesFast.Add(enemyFast);

			EnemyView enemyBig = Instantiate<EnemyView>(Resources.Load<EnemyView>("EnemyBig"));
			enemyBig.setActive(false);
			enemyBig.transform.SetParent(gameObject.transform);
			enemyBig.id = i;
            enemiesBig.Add(enemyBig);

			EnemyView enemyStrong = Instantiate<EnemyView>(Resources.Load<EnemyView>("EnemyStrong"));
			enemyStrong.setActive(false);
			enemyStrong.transform.SetParent(gameObject.transform);
			enemyStrong.id = i;
            enemiesStrong.Add(enemyStrong);
        }
    }

    public EnemyView GetPooledEnemy(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.NORMAL:
                {
					for (int i = 0; i < enemiesNormal.Count; i++)
					{
						if (!enemiesNormal[i].activeInHierarchy())
						{
							return enemiesNormal[i];
						}
					}
					if (willGrow)
					{
						EnemyView enemy = Instantiate<EnemyView>(Resources.Load<EnemyView>("EnemyNormal"));
						enemiesNormal.Add(enemy);
						return enemy;
					}
                    break;
                }
            case EnemyType.FAST:
                {
                    for (int i = 0; i < enemiesFast.Count; i++)
					{
						if (!enemiesFast[i].activeInHierarchy())
						{
							return enemiesFast[i];
						}
					}
					if (willGrow)
					{
						EnemyView enemy = Instantiate<EnemyView>(Resources.Load<EnemyView>("EnemyFast"));
						enemiesFast.Add(enemy);
						return enemy;
					}
                    break;
                }
            case EnemyType.BIG:
                {
                    for (int i = 0; i < enemiesBig.Count; i++)
					{
						if (!enemiesBig[i].activeInHierarchy())
						{
							return enemiesBig[i];
						}
					}
					if (willGrow)
					{
						EnemyView enemy = Instantiate<EnemyView>(Resources.Load<EnemyView>("EnemyBig"));
						enemiesBig.Add(enemy);
						return enemy;
					}
                    break;
                }
            case EnemyType.STRONG:
                {
                    for (int i = 0; i < enemiesStrong.Count; i++)
					{
						if (!enemiesStrong[i].activeInHierarchy())
						{
							return enemiesStrong[i];
						}
					}
					if (willGrow)
					{
						EnemyView enemy = Instantiate<EnemyView>(Resources.Load<EnemyView>("EnemyStrong"));
						enemiesStrong.Add(enemy);
						return enemy;
					}
                    break;
                }
             default:
                return null;
        }
        return null;
    }

	public void KillEnemy(EnemyType enemyType, int id)
	{
        switch (enemyType)
        {
            case EnemyType.NORMAL:
                {
                    enemiesNormal[id].setActive(false);
                    break;
                }
            case EnemyType.FAST:
                {
                    enemiesFast[id].setActive(false);
                    break;
                }
            case EnemyType.BIG:
                {
                    enemiesBig[id].setActive(false);
                    break;
                }
            case EnemyType.STRONG:
                {
                    enemiesStrong[id].setActive(false);
                    break;
                }
        }
        Explore(enemyType, id);
	}

    public EnemyView GetNearestEnemy()
	{
        int nearestEnemyID = -1;
        EnemyView result = new EnemyView();
        foreach (EnemyView enemy in enemiesNormal.Concat(enemiesFast).Concat(enemiesBig).Concat(enemiesStrong))
        {
            if (enemy.activeInHierarchy())
            {
				if (enemy.data.isInAttackQueue)
				{
					curDistance = Vector3.Distance(new Vector3(0, 0, 0), enemy.transform.position);
					if (curDistance < minDistance)
					{
						nearestEnemyID = enemy.id;
                        result = enemy;
						minDistance = curDistance;
					}
				}
            }
        }
        minDistance = Mathf.Infinity;
        if (nearestEnemyID == -1)
        {
            return null;
        } else 
        {
            return result;
        }
	}

    private void Explore(EnemyType enemyType, int id)
    {
        Vector3 position = new Vector3();
        switch (enemyType)
        {
            case EnemyType.NORMAL:
                {
                    position = enemiesNormal[id].transform.position;
                    break;
                }
            case EnemyType.FAST:
                {
                    position = enemiesFast[id].transform.position;
                    break;
                }
            case EnemyType.BIG:
                {
                    position = enemiesBig[id].transform.position;
                    break;
                }
            case EnemyType.STRONG:
                {
                    position = enemiesStrong[id].transform.position;
                    break;
                }
        }
		GameObject explosion = Instantiate(Resources.Load("Explosion")) as GameObject;
        explosion.transform.position = position;
        Destroy(explosion, 1f);
    }
}