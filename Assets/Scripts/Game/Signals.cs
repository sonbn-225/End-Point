using strange.extensions.signal.impl;
using System;

public class SpawnEnemySignal : Signal<ISpawner> { }
public class InitiateTowerSignal : Signal<ISpawner>{}
public class SpawnBulletSignal : Signal<ISpawner>{}
public class BulletHitEnemySignal : Signal<float,EnemyView> { }
public class TowerShootSignal : Signal { }
