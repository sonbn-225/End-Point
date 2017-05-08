using UnityEngine;
using System.Collections;
using strange.extensions.pool.api;

public class Player : IPlayer {
	#region IPlayer implementation

	public float damage { get; set; }

	public float attackSpeed { get; set; }

	public float critRate { get; set; }

	public float critFactor { get; set; }

	public float attackRange { get; set; }

	public float health { get; set; }

	public float regenerateSpeed { get; set; }

	public float resourceBonus { get; set; }

	#endregion

	public Player() {
		damage = 20;
	}
}
