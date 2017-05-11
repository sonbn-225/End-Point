using strange.extensions.signal.impl;

public class SpawnEnemySignal : Signal<IEnemySpawner> { }
public class BulletHitSignal : Signal<IDestroyable, BulletView> { }
public class PlayerAttackSignal : Signal<IPlayer> { }