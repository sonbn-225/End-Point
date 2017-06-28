using strange.extensions.signal.impl;
using System;
using UnityEngine;

public class GameStartSignal : Signal { }
public class SpawnEnemySignal : Signal<ISpawner, Vector3> { }
public class SpawnBulletSignal : Signal<ISpawner>{}
public class BulletHitEnemySignal : Signal<bool,EnemyView> { }
public class TowerShootSignal : Signal<TowerView> { }
public class EnemyAttackSignal : Signal<float> { }
public class EnterAttackRangeSignal : Signal<EnemyView> { }
