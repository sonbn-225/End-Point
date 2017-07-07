using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace endpoint.game
{
	public class Bullet : IBullet
	{
		public EnemyView enemy { get; set; }

		public Vector3 target { get; set; }

		public bool isKillEnemy { get; set; }

		public float speed { get; set; }
	}
}

