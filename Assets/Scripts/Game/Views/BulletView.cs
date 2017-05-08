using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class BulletView : View, IDestroyable {
	public bool Destroy (float dame)
	{
		throw new System.NotImplementedException ();
	}

    public readonly Signal<EnemyView> BulletHitEnemySignal = new Signal<EnemyView>();
	public IBullet properties = new Bullet ();
	private float speed = Random.Range (30f, 500f);

	protected override void Start() {
		base.Start();
		Debug.Log (properties.damage);
	}

	private void Update () {
		transform.position = Vector3.MoveTowards (transform.position, properties.enemy.position, speed * Time.deltaTime);
		if (properties.enemy == null) {
			Destroy ();
		}
	}

    private void OnCollisionEnter(Collision collision) {
        foreach (ContactPoint contact in collision.contacts) {
            if (contact.otherCollider.GetComponent<EnemyView>()) {
                BulletHitEnemySignal.Dispatch(contact.otherCollider.GetComponent<EnemyView>());
            }
        }
    }

    public void Destroy() {
        Destroy(gameObject);
    }
}
