using UnityEngine;
using System.Collections;

public class Enemy : IEnemy {
	#region IEnemy implementation

    public int id { get; set; }

	public float speed { get; set; }

	public float health { get; set; }
     
    public float damage { get; set; }

    public int score { get; set; }

	public Vector3 target { get; set; }

	#endregion
}
