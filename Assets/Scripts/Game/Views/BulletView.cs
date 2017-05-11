using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class BulletView : View, IDestroyable, IBullet {
	public Vector3 enemy { get; set; }
	public float damage { get; set; }
	public float speed { get; set; }
	public bool Destroy (float dame)
	{
		return true;
	}

    public readonly Signal<EnemyView> BulletHitEnemySignal = new Signal<EnemyView>();


	protected override void Start() {
		base.Start();
		speed = 15f;
	}

	private void Update () {
		transform.position = Vector3.MoveTowards (transform.position, enemy, speed * Time.deltaTime);
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
