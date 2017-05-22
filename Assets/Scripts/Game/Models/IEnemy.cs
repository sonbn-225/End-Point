using UnityEngine;
using System.Collections;

public interface IEnemy {

	int id { get; set; }
	float speed { get; set; }
	float health { get; set; }
	float damage { get; set; }
	int score { get; set; }

	Vector3 target { get; set; }
}
