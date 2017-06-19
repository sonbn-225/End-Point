using UnityEngine;
using System.Collections;

public interface IBullet {
    EnemyView enemy { get; set; }
	float damage { get; set; }
	float speed { get; set; }
}
