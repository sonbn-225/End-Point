using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : IBullet {
    public EnemyView enemy { get; set; }

    public float damage { get; set; }

    public float speed { get;set; }
}
