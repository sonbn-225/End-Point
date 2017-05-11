using UnityEngine;
using System.Collections;

public interface IEnemyManager
{
	void AddEnemy (EnemyView enemy);
	EnemyView KillEnemy ();
	EnemyView GetNearestEnemy ();
}

