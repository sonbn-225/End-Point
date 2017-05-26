using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPools : MonoBehaviour {

	private const int MAX_POOL_SIZE = 100;
	public List<EnemyView> enemies = new List<EnemyView>();

	public void create(EnemyView enemy){
		enemy.data.speed = 5f;
		enemy.data.health = 100f;
		enemy.data.damage = 2f;
		enemy.data.score = 10;
		enemies.Add (enemy);
	}
}
