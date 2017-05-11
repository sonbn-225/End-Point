using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using System;

public class PlayerView : View, IPlayer {
	public readonly Signal PlayerAttackSignal = new Signal ();

	public float timer = 0f;

	public float damage { get; set; }
	public float attackSpeed { get; set; }
	public float critRate { get; set; }
	public float critFactor { get; set; }
	public float attackRange { get; set; }

	public float health { get; set; }
	public float regenerateSpeed { get; set; }

	public float resourceBonus { get; set; }

	public EnemyView target { get; set; }

	protected override void Start(){
		base.Start ();
		timer = 0f;
	}

	private void Update(){
		timer += Time.deltaTime;
		if (timer > 1f) {
			timer = 0f;
			PlayerAttackSignal.Dispatch ();
		}
	}

	public void Fire(){
		BulletView bullet = GameObject.Instantiate<BulletView> (Resources.Load<BulletView> ("Bullet"));
		bullet.damage = damage;
		bullet.enemy = target.transform.position;
		bullet.transform.SetParent(transform.parent);
		bullet.transform.position = new Vector3(0, 4, -15);
	}

	public void UpgradeDamage(float ratio){
		damage *= ratio;
	}

	public void UpgradeAttackSpeed(float ratio){
		attackSpeed *= ratio;
	}

	public void UpgradeCritRate(float ratio){
		critRate *= ratio;
	}

	public void UpgradeCritFactor(float ratio){
		critFactor *= ratio;
	}

	public void UpgradeAttackRange(){
		attackRange += 0.5f;
	}

	public void UpgradeHealth(float ratio){
		health *= ratio;
	}

	public void UpgradeRegenerateSpeed(float ratio){
		regenerateSpeed *= ratio;
	}

	public void UpgradeResourceBonus(float ratio){
		resourceBonus *= ratio;
	}
}
