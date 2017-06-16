using UnityEngine;
using System.Collections;

public interface IEnemy {

	float speed { get; set; }
	float health { get; set; }
	float damage { get; set; }
	int score { get; set; }
    float distance { get; set; }
    bool isInAttackQueue { get; set; }
	Vector3 target { get; set; }
}
