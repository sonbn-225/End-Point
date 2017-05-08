using UnityEngine;
using System.Collections;

public class Bullet : IBullet {
	#region IBullet implementation

	public Transform enemy { get; set; }

	public float damage { get; set; }

	public float speed { get; set; }

	#endregion


}
