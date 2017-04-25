using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class BulletView : View, IDestroyable {

    public readonly Signal<EnemyView> BulletHitEnemySignal = new Signal<EnemyView>();

	private NavMeshAgent nav;
	private Transform enemy;

	protected override void Start() {
		base.Start();
		nav = GetComponent<NavMeshAgent> ();
	}

	private void Update () {
		enemy = GameObject.FindGameObjectWithTag ("Enemy").transform;
		nav.SetDestination (enemy.position);
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
