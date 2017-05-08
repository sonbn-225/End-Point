using UnityEngine;
using System.Collections;
using System.CodeDom.Compiler;

public class EnemyManager : MonoBehaviour {
	private const Vector3 player = new Vector3 (0,0,-15);

	public ArrayList enemies { get; set; }

	public void addEnemy(EnemyView enemy) {
		enemies.Add (enemy);
	}

	public void removeEnemy(EnemyView enemy){
		enemies.Remove (enemy);
	}

	public EnemyView chooseEnemy(){
		float distance = 1000f;
		EnemyView result = null;
		foreach (EnemyView enemy in enemies) {
			float temp = Vector3.Distance (enemy.transform.position, player);
			if (temp < distance) {
				distance = temp;
				result = enemy;
			}
		}
		return result;
	}
}
