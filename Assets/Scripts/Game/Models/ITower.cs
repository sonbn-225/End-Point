using UnityEngine;
using System.Collections;

public interface ITower {
	float damage { get; set; }
	int attackSpeed { get; set; }
	float critRate { get; set; }
	float critFactor { get; set; }
	float attackRange { get; set; }

	float health { get; set; }
	float regenerateSpeed { get; set; }

	float resourceBonus { get; set; }
}
