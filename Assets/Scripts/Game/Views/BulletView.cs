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
        transform.position = Vector3.MoveTowards (transform.position, data.enemy.transform.position, data.speed * Time.deltaTime);
        if (Vector3.Distance(data.enemy.transform.position, gameObject.transform.position) < 0.01f)
        {
            BulletHitEnemySignal.Dispatch(data.enemy);
			Reset();
        }
	}


    public void Reset() {
        gameObject.SetActive(false);
    }

	public void setActive(bool value)
	{
		gameObject.SetActive(value);
	}

	public bool activeInHierarchy()
	{
		return gameObject.activeInHierarchy;
	}
}
