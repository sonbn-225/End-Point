using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class EnemyView : View
{
    public IEnemy data { get; set; }

    [Inject]
    public IGameModel gameModel { get; set; }

    private void FixedUpdate()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, data.target, gameModel.gameSpeed*data.speed * Time.deltaTime);
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