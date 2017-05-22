using UnityEngine;
using System.Collections;

public class EnemyManager : IEnemyManager {
	#region IEnemyManager implementation

	public void AddEnemy (EnemyView enemy)
	{
		Debug.Log ("EnemyManager: " + enemy.data.id);
		enemies.Enqueue (enemy);
	}

	public EnemyView KillEnemy ()
	{
		return (EnemyView) enemies.Dequeue ();
	}

	public EnemyView GetNearestEnemy(){
		return (EnemyView) enemies.Peek ();
	}

	#endregion

	Queue enemies = new Queue ();
}
