using strange.extensions.signal.impl;
using System;
using UnityEngine;

namespace endpoint.game
{
    //Game
    public class GameStartedSignal : Signal { }

    //Tower
    public class CreateTowerSignal : Signal { }
    //TowerView - reference to tower
    //bool - False indicates destruction. True indicates cleanup at end of level.
    public class DestroyTowerSignal : Signal<TowerView, bool> { }

    //Enemy
    //int - level of enemy
    //Vector3, position
    //EnemyType - BIG, FAST< NORMAL, STRONG
    public class CreateEnemySignal : Signal<int, Vector3, EnemyType> { }
    //EnemyView - reference to the specific enemy
    //bool - True indicates player gets points. False is simple cleanup.
    public class DestroyEnemySignal : Signal<EnemyView, bool> { }
    //EnemyView - reference to which enemy enter attack range
    public class EnterAttackRangeSignal : Signal<EnemyView>{}

    //Bullet
    //GameObject - The GameObject that fired the bullet
    //GameElemet - ID to indicate if it is a Player or Enemy missile
    public class FireBulletSignal : Signal<Vector3, GameObject, GameElement, float> { }
    //BulletView - reference to the specific bullet
    //GameElement - ID to indicate if it was a Player or Enemy missile
    public class DestroyBulletSignal : Signal<BulletView, GameElement> { }
    //BulletView - reference to the specific bullet
    //GameObject - The contact with which the bullet collided
    public class BulletHitSignal : Signal<BulletView, GameObject> { }

    //Level
    public class SetupLevelSignal : Signal { }
    public class LevelStartedSignal : Signal { }

    //Update value signal
    public class UpdateGameSpeedSignal : Signal { }
    public class UpdateAttackSpeedSignal : Signal { }
    public class UpdateIsGameOverSignal : Signal { }
}
