using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : ITower {
    public float damage { get; set; }
    public int attackSpeed { get; set; }
    public float critRate { get; set; }
    public float critFactor { get; set; }
    public float attackRange { get; set; }
    public float health { get; set; }
    public float regenerateSpeed { get; set; }
    public float resourceBonus { get; set; }
}
