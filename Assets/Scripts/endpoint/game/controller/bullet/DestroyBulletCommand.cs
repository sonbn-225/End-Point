using System.Collections;
using System;
using strange.extensions.command.impl;
using strange.extensions.pool.api;
using UnityEngine;

namespace endpoint.game
{
    public class DestroyBulletCommand : Command
    {
        [Inject]
        public BulletView bulletView { get; set; }

        [Inject]
        public GameElement id { get; set; }

        [Inject(GameElement.ENEMY_BULLET_POOL)]
        public IPool<GameObject> enemyBulletPool { get; set; }

        [Inject(GameElement.TOWER_BULLET_POOL)]
        public IPool<GameObject> towerBulletPool { get; set; }

        private static Vector3 PARKED_POS = new Vector3(1000f, 0f, 1000f);

        public override void Execute()
        {
            bulletView.transform.localPosition = PARKED_POS;

            if (id == GameElement.ENEMY_BULLET_POOL)
            {
                enemyBulletPool.ReturnInstance(bulletView.gameObject);
            } else if (id  == GameElement.TOWER_BULLET_POOL)
            {
                towerBulletPool.ReturnInstance(bulletView.gameObject);
            } else 
            {
                throw new Exception("DestroyMissileCommand unrecognized pool id " + id);
            }
            bulletView.gameObject.SetActive(false);
        }
    }
}
