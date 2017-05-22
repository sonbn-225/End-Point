using strange.extensions.signal.impl;
using System;

public class SpawnEnemySignal : Signal<ISpawner> { }
public class InitiateTowerSignal : Signal<ISpawner>{}
public class BulletHitEnemySignal : Signal<Int32, EnemyView> { }
public class TowerShootSignal : Signal<ITower> { }
