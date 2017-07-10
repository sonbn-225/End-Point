using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace endpoint.game
{
	public class Bullet : IBullet
	{
        public GameObject targetObject { get; set; }

		public Vector3 targetPosition { get; set; }

		public bool isKillEnemy { get; set; }

		public float speed { get; set; }
	}
}

