using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class EnemyView : View, IDestroyable, IEnemy {
	public readonly Signal EnterPlayerAttackRangeSignal = new Signal ();

	#region IEnemy implementation

	public void takeDamage (float dame)
	{
	}

	public Transform player { get; set; }

	public float speed { get; set; }

	public float health { get; set; }

	public float damage { get; set; }

	public float distance { get; set; }

	public int ID { get; set; }

	#endregion

	public void Destroy ()
	{
		throw new System.NotImplementedException ();
	}

	private bool isAttackable = false;
    public Vector3 Velocity { get; internal set; }

	public bool Destroy(float dame) {
		takeDamage (dame);
		if (health <= 0) {
			Destroy (gameObject);
			return true;
		} else {
			return false;
		}
    }

    protected override void Start() {
        base.Start();
		speed = 3f;
		distance = Vector3.Distance (transform.position, player.position);
    }

    private void Update () {
		transform.position = Vector3.MoveTowards (transform.position, player.position, speed * Time.deltaTime);
		distance = Vector3.Distance (transform.position, player.position);
		if (distance < 20f && !isAttackable) {
			EnterPlayerAttackRangeSignal.Dispatch ();
			isAttackable = true;
		}
    }
}
