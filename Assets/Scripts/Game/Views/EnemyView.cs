using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class EnemyView : View {
	public readonly Signal EnterPlayerAttackRangeSignal = new Signal ();

	public IEnemy data { get; set; }

    protected override void Start() {
        base.Start();
    }

    private void Update () {
		transform.position = Vector3.MoveTowards (transform.position, data.target, data.speed * Time.deltaTime);
    }

	public void TakeDamage(float damage){
		data.damage -= damage;
		if (data.damage <= 0) {
			Destroy ();
		}
	}

	public void Destroy(){
		Destroy (gameObject);
	}
}
