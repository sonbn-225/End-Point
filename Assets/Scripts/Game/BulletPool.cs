using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MySingleton<BulletPool> 
{
    private const int MAX_BULLET_POOL_SIZE = 10;
    public List<BulletView> bullets = new List<BulletView>();

    public bool willGrow = false;

	[Inject]
	public ITower towerData { get; set; }

	protected void Start()
	{
        bullets = new List<BulletView>();
		for (int i = 0; i < MAX_BULLET_POOL_SIZE; i++)
		{
            BulletView bullet = Instantiate<BulletView>(Resources.Load<BulletView>("Bullet"));
            bullet.transform.SetParent(gameObject.transform);
			bullets.Add(bullet);
            bullet.setActive(false);
		}
	}

	public BulletView GetPooledBullet()
	{
		for (int i = 0; i < bullets.Count; i++)
		{
			if (!bullets[i].activeInHierarchy())
			{
				return bullets[i];
			}
		}
		if (willGrow)
		{
            BulletView bullet = Instantiate<BulletView>(Resources.Load<BulletView>("Bullet"));
			bullets.Add(bullet);
			return bullet;
		}
		return null;
	}
}
