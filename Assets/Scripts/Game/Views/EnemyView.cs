using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class EnemyView : View {
	public readonly Signal EnterPlayerAttackRangeSignal = new Signal ();

	public IEnemy data { get; set; }

    void Start() {
        base.Start();
		Debug.Log ("Enemy View");
    }

    void Update () {
		Debug.Log (data.id);
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
