using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class EnemyView : View
{
    public IEnemy data { get; set; }

    public Signal enterAttackRangeSignal = new Signal();
    public Signal enemyAttackSignal = new Signal();

    [Inject]
    public IGameModel gameModel { get; set; }

    [Inject]
    public ITower towerData { get; set; }


    public int id { get; set; }

    public GameObject normalForm, fastForm, bigForm, strongForm;

    private void FixedUpdate()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, data.target, gameModel.gameSpeed*data.speed * Time.deltaTime);
        if (!data.isInAttackQueue)
        {
			if (Vector3.Distance(transform.position, data.target) <= towerData.attackRange)
			{
				data.isInAttackQueue = true;
                enterAttackRangeSignal.Dispatch();
			}
        }
    }



    public bool TakeDamage(float damage)
    {
        data.health -= damage;
        if (data.health <= 0)
        {
            EnemyPool.Instance.enemiesToAttack.Remove(this);
            data.isInAttackQueue = false;
            return true;
        }
        return false;
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

    public EnemyView SetEnemyForm(EnemyType enemyType)
	{
        switch (enemyType)
        {
            case EnemyType.NORMAL:
                {
                    DisableAllForm();
                    normalForm.SetActive(true);
                    break;
                }
            case EnemyType.FAST:
                {
                    DisableAllForm();
                    fastForm.SetActive(true);
                    break;
                }
            case EnemyType.BIG:
                {
                    DisableAllForm();
					bigForm.SetActive(true);
                    break;
                }
            case EnemyType.STRONG:
                {
                    DisableAllForm();
					strongForm.SetActive(true);
                    break;
                }
        }
        return this;
	}

    private void DisableAllForm()
    {
		normalForm.SetActive(false);
		fastForm.SetActive(false);
		bigForm.SetActive(false);
        strongForm.SetActive(false);
    }
}