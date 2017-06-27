using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IGameManager
{
	public GameObject enemyManager, ground, pool;
    private TowerView tower;

	[Inject]
	public ITower towerData { get; set; }

    [Inject]
    public IGameModel gameModel { get; set; }

	public void InitEnemySpawner()
	{
		enemyManager = Instantiate(Resources.Load("EnemySpawner")) as GameObject;
		enemyManager.transform.SetParent(GameObject.FindGameObjectWithTag("GameManager").transform, false);
		enemyManager.SetActive(true);
	}

	public void InitGround()
	{
		ground = Instantiate(Resources.Load("Ground")) as GameObject;
		ground.transform.SetParent(GameObject.FindGameObjectWithTag("GameManager").transform, false);
		ground.SetActive(true);
	}

	public void InitTower()
	{
		tower = Instantiate<TowerView>(Resources.Load<TowerView>("Tower"));
		tower.transform.position = new Vector3(0, 0, 0);
		tower.transform.SetParent(GameObject.FindGameObjectWithTag("GameManager").transform, false);
        gameModel.towerTransform = tower.transform;
		towerData.damage = 100f;
		towerData.attackSpeed = 1;
		towerData.critRate = 1f;
		towerData.critFactor = 1f;
		towerData.attackRange = 20f;
		towerData.health = 200f;
		towerData.regenerateSpeed = 0f;
		towerData.resourceBonus = 1f;

        gameModel.attackInterval = 1f / (gameModel.gameSpeed * towerData.attackSpeed);
	}

    public void InitPool()
    {
        pool = Instantiate(Resources.Load("Pool")) as GameObject;
        pool.transform.SetParent(GameObject.FindGameObjectWithTag("GameManager").transform, false);
        pool.SetActive(true);
    }
}
