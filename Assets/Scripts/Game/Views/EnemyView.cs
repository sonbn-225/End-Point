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
        if (Vector3.Distance(transform.position, data.target) <= towerData.attackRange && !data.isInAttackQueue)
        {
            data.isInAttackQueue = true;
            EnemyPools.Instance.AddEnemyToAttack(id);
        }
    }

    public void TakeDamage(float damage)
    {
        data.damage -= damage;
        if (data.damage <= 0)
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
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