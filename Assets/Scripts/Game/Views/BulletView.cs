using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class BulletView : View {
	public IBullet data { get; set; }

	public bool Destroy (float dame)
	{
		return true;
	}

    public readonly Signal<EnemyView> BulletHitEnemySignal = new Signal<EnemyView>();


	protected override void Start() {
		base.Start();
	}

	private void Update () {
        transform.position = Vector3.MoveTowards (transform.position, data.enemy, data.speed * Time.deltaTime);
	}

    private void OnCollisionEnter(Collision collision) {
        foreach (ContactPoint contact in collision.contacts) {
			if (contact.otherCollider.GetComponent<EnemyView> ()) {
				BulletHitEnemySignal.Dispatch (contact.otherCollider.GetComponent<EnemyView> ());
			} else if (contact.otherCollider.CompareTag ("Ground")) {
				Destroy ();
			}
        }
    }

    public void Destroy() {
        Destroy(gameObject);
    }
}
