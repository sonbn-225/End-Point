using UnityEngine;
using System.Collections;

public class Enemy : IEnemy {
	#region IEnemy implementation

	public Transform player { get; set; }

	public float speed { get; set; }

	public float health { get; set; }

	public float damage { get; set; }

	#endregion

	public Enemy(){
		health = 40;
	}

	public void takeDamage(float dame){
		health -= dame;
	}
}
