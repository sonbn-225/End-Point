﻿using strange.extensions.command.impl;
using strange.extensions.pool.api;
using UnityEngine;

namespace endpoint.game
{
	public class BulletHitCommand : Command
	{

		[Inject]
        public BulletView bulletView { get; set; }

        [Inject]
        public GameObject contact { get; set; }

        [Inject(GameElement.EXPLOSION_POOL)]
        public IPool<GameObject> pool { get; set; }

        [Inject]
        public DestroyEnemySignal destroyEnemySignal { get; set; }

        [Inject]
        public DestroyBulletSignal destroyBulletSignal { get; set; }

        public override void Execute()
        {
            GameObject explosionGO = pool.GetInstance();
            explosionGO.AddComponent<ExplosionView>();
            explosionGO.SetActive(true);
            Vector3 pos = bulletView.transform.localPosition;
            explosionGO.transform.localPosition = pos;
            explosionGO.transform.parent = bulletView.transform.parent;

            //Destroy the bullet
            GameElement id = bulletView.gameObject.name.IndexOf("Enemy") > -1 ? GameElement.ENEMY_BULLET_POOL : GameElement.TOWER_BULLET_POOL;
            destroyBulletSignal.Dispatch(bulletView, id);

            //When hit...
            EnemyView enemyView = contact.GetComponent<EnemyView>();
            if (enemyView != null)
            {
                destroyEnemySignal.Dispatch(enemyView, true);
            }

            BulletView otherBulletView = contact.GetComponent<BulletView>();
            if (otherBulletView != null)
            {
                GameElement otherID = (id == GameElement.ENEMY_BULLET_POOL) ? GameElement.TOWER_BULLET_POOL : GameElement.ENEMY_BULLET_POOL;
                destroyBulletSignal.Dispatch(otherBulletView, otherID);
            }
        }
	}
}