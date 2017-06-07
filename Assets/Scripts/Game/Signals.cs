using strange.extensions.signal.impl;
using System;
using UnityEngine;

public class SpawnEnemySignal : Signal<ISpawner, Vector3> { }
public class InitiateTowerSignal : Signal<ISpawner>{}
public class SpawnBulletSignal : Signal<ISpawner>{}
public class BulletHitEnemySignal : Signal<float,EnemyView> { }
public class TowerShootSignal : Signal<TowerView> { }
public class ButtonClickSignal : Signal<string> { }