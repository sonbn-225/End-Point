using UnityEngine;
using System.Collections;

public interface IEnemy {

	Transform player { get; set; }
	float speed { get; set; }
	float health { get; set; }
	float damage { get; set; }
	void takeDamage (float dame);
}
