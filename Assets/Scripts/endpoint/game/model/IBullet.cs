using UnityEngine;
using System.Collections;

namespace endpoint.game
{
	public interface IBullet
	{
        GameObject targetObject { get; set; }
		Vector3 targetPosition { get; set; }
		bool isKillEnemy { get; set; }
		float speed { get; set; }
	}
}

