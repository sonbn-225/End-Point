using UnityEngine;
using strange.extensions.mediation.impl;
using DG.Tweening;

public class EnemyView : View, IDestroyable {
	public void Destroy ()
	{
		throw new System.NotImplementedException ();
	}

    public Vector3 Velocity { get; internal set; }
	public IEnemy properties =  new Enemy ();
	private float speed = 2f;

	public bool Destroy(float dame) {
		properties.takeDamage (dame);
		if (properties.health <= 0) {
			Destroy (gameObject);
			return true;
		} else {
			return false;
		}
    }

    protected override void Start() {
        base.Start();
    }

    private void Update () {
		transform.position = Vector3.MoveTowards (transform.position, properties.player.position, speed * Time.deltaTime);
    }
}
