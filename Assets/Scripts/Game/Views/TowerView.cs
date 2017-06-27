﻿using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using System;

public class TowerView : View {
	public readonly Signal TowerShootSignal = new Signal ();

    public float timer = 0f;

    public EnemyView target;

    private bool isKillEnemy = false;

    [Inject]
	public ITower data { get; set; }

	[Inject]
	public IGameModel gameModel { get; set; }

    protected override void Start(){
		base.Start ();
		timer = 0f;
	}

	private void FixedUpdate()
    {
		timer += Time.deltaTime;
        if (timer >= gameModel.attackInterval) 
        {
            target = EnemyPool.Instance.GetNearestEnemy();
            if (target != null && target.data.health > 0)
			{
                isKillEnemy = target.TakeDamage(data.damage);
				TowerShootSignal.Dispatch();
			}
            timer = 0f;
        }
	}

    private void Attack()
    {
        target = EnemyPool.Instance.GetNearestEnemy();
    }

	public void Fire(){
        BulletView bullet = BulletPool.Instance.GetPooledBullet();
        if (bullet == null)
        {
            return;
        }
        bullet.transform.position = new Vector3(0, 4, 0);
		bullet.transform.forward = transform.forward;
		bullet.setActive(true);
        bullet.data = new Bullet()
        {
            enemy = target,
            target = FirstOrderIntercept(bullet.transform.position, Vector3.zero, 20f * gameModel.gameSpeed, target.transform.position, Vector3.zero),
            isKillEnemy = isKillEnemy,
            speed = 40f*gameModel.gameSpeed
        };
	}

	//first-order intercept using absolute target position
	public static Vector3 FirstOrderIntercept (Vector3 shooterPosition, Vector3 shooterVelocity, float shotSpeed, Vector3 targetPosition, Vector3 targetVelocity)
	{
		Vector3 targetRelativePosition = targetPosition - shooterPosition;
		Vector3 targetRelativeVelocity = targetVelocity - shooterVelocity;
		float t = FirstOrderInterceptTime
		(
			shotSpeed,
			targetRelativePosition,
			targetRelativeVelocity
		);
		return targetPosition + t * (targetRelativeVelocity);
	}

	//first-order intercept using relative target position
	public static float FirstOrderInterceptTime (float shotSpeed, Vector3 targetRelativePosition, Vector3 targetRelativeVelocity)
	{
		float velocitySquared = targetRelativeVelocity.sqrMagnitude;
		if (velocitySquared < 0.001f)
			return 0f;

		float a = velocitySquared - shotSpeed * shotSpeed;

		//handle similar velocities
		if (Mathf.Abs(a) < 0.001f)
		{
			float t = -targetRelativePosition.sqrMagnitude /
			(
				2f * Vector3.Dot
				(
					targetRelativeVelocity,
					targetRelativePosition
				)
			);
			return Mathf.Max(t, 0f); //don't shoot back in time
		}

		float b = 2f * Vector3.Dot(targetRelativeVelocity, targetRelativePosition);
		float c = targetRelativePosition.sqrMagnitude;
		float determinant = b * b - 4f * a * c;

		if (determinant > 0f)
		{ //determinant > 0; two intercept paths (most common)
			float t1 = (-b + Mathf.Sqrt(determinant)) / (2f * a),
					t2 = (-b - Mathf.Sqrt(determinant)) / (2f * a);
			if (t1 > 0f)
			{
				if (t2 > 0f)
					return Mathf.Min(t1, t2); //both are positive
				else
					return t1; //only t1 is positive
			}
			else
				return Mathf.Max(t2, 0f); //don't shoot back in time
		}
		else if (determinant < 0f) //determinant < 0; no intercept path
			return 0f;
		else //determinant = 0; one intercept path, pretty much never happens
			return Mathf.Max(-b / (2f * a), 0f); //don't shoot back in time
	}
}
