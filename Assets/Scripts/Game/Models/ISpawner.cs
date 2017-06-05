using UnityEngine;

public interface ISpawner {
	void SpawnEnemy(Vector3 position);
	void InitiateTower ();
	void SpawnBullet ();
}
