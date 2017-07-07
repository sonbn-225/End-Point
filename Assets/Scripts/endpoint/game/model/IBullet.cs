using UnityEngine;
using System.Collections;

namespace endpoint.game
{
	public interface IBullet
	{
		EnemyView enemy { get; set; }
		Vector3 target { get; set; }
		bool isKillEnemy { get; set; }
		float speed { get; set; }
	}
}

