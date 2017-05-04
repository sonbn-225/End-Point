using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class BulletView : View, IDestroyable {

    public readonly Signal<EnemyView> BulletHitEnemySignal = new Signal<EnemyView>();

	private Transform enemy;
	private float speed = Random.Range (30f, 500f);

	protected override void Start() {
		base.Start();
	}

	private void Update () {
		enemy = GameObject.FindGameObjectWithTag ("Enemy").transform;
		transform.position = Vector3.MoveTowards (transform.position, enemy.position, speed * Time.deltaTime);
		if (enemy == null) {
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
