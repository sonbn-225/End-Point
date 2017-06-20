using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class EnemyView : View
{
    public IEnemy data { get; set; }

    [Inject]
    public IGameModel gameModel { get; set; }

    [Inject]
    public ITower towerData { get; set; }


    public int id { get; set; }

    private void FixedUpdate()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, data.target, gameModel.gameSpeed*data.speed * Time.deltaTime);
        if (!data.isInAttackQueue)
        {
			if (Vector3.Distance(transform.position, data.target) <= towerData.attackRange)
			{
				data.isInAttackQueue = true;
			}
        }
    }

    public void TakeDamage(float damage)
    {
        data.health -= damage;
        if (data.health <= 0)
        {
            EnemyPools.Instance.KillEnemy(data.enemyType, id);
			data.isInAttackQueue = false;
		}
    }


    //For enemyPool
    public void setActive(bool value)
    {
        gameObject.SetActive(value);
    }

    public bool activeInHierarchy()
    {
        return gameObject.activeInHierarchy;
    }
}