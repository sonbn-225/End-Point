﻿using strange.extensions.command.impl;
using strange.extensions.pool.api;
using UnityEngine;

namespace endpoint.game
{
	public class BulletHitTargetCommand : Command
	{

		[Inject]
        public BulletView bulletView { get; set; }

        [Inject]
        public GameObject target { get; set; }

        [Inject(GameElement.EXPLOSION_POOL)]
        public IPool<GameObject> pool { get; set; }

        [Inject]
        public EnemyTakeHitSignal enemyTakeHitSignal { get; set; }

        [Inject]
        public DestroyBulletSignal destroyBulletSignal { get; set; }

        [Inject]
        public TowerTakeHitSignal towerTakeHitSignal { get; set; }

        //to do: specify signal
        [Inject]
        public UpdateInformationSignal updateScoreSignal { get; set; }

        [Inject]
        public ITower towerData { get; set; }

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
            if (id == GameElement.ENEMY_BULLET_POOL)
            {
				TowerView towerView = target.GetComponent<TowerView>();
				if (towerView != null)
				{
                    //Actual update health
					updateScoreSignal.Dispatch();
                    if (bulletView.data.isKillTarget)
					{
						towerTakeHitSignal.Dispatch(towerView, bulletView.data.isKillTarget);
					}
				}
            } else
            {
				EnemyView enemyView = target.GetComponent<EnemyView>();
				if (bulletView.data.isKillTarget)
				{
					enemyTakeHitSignal.Dispatch(enemyView, bulletView.data.isKillTarget);
				}
            }
        }
	}
}