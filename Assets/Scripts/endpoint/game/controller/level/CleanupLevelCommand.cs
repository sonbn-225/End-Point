using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using UnityEngine;

namespace endpoint.game
{
    public class CleanupLevelCommand : Command
    {
        [Inject(GameElement.GAME_FIELD)]
        public GameObject gameField { get; set; }

        [Inject]
        public DestroyTowerSignal destroyTowerSignal { get; set; }

        [Inject]
        public DestroyEnemySignal destroyEnemySignal { get; set; }

        [Inject]
        public DestroyBulletSignal destroyBulletSignal { get; set; }

        public override void Execute()
        {
            //Cleanup tower
            if (injectionBinder.GetBinding<TowerView>(GameElement.TOWER) != null)
            {
                TowerView towerView = injectionBinder.GetInstance<TowerView>(GameElement.TOWER);
                destroyTowerSignal.Dispatch(towerView, true);
            }

            //CLeanup enemies
            EnemyView[] enemies = gameField.GetComponentsInChildren<EnemyView>();
            foreach (EnemyView enemy in enemies)
            {
                destroyEnemySignal.Dispatch(enemy, false);
            }

            //Cleanup bullet
            BulletView[] bullets = gameField.GetComponentsInChildren<BulletView>();
            foreach(BulletView bullet in bullets)
            {
                GameElement id = (bullet.gameObject.name.IndexOf("EnemyBullet", System.StringComparison.CurrentCulture) > -1) ? GameElement.ENEMY_BULLET_POOL : GameElement.TOWER_BULLET_POOL;
                destroyBulletSignal.Dispatch(bullet, id);
            }
        }
    }
}
