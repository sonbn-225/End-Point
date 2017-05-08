using UnityEngine;
using System.Collections;

public interface IBullet {
	Transform enemy { get; set; }
	float damage { get; set; }
	float speed { get; set; }
}
