﻿using UnityEngine;
using System.Collections;

public interface IPlayer {
	float damage { get; set; }
	float attackSpeed { get; set; }
	float critRate { get; set; }
	float critFactor { get; set; }
	float attackRange { get; set; }

	float health { get; set; }
	float regenerateSpeed { get; set; }

	float resourceBonus { get; set; }

	void Fire ();
}
