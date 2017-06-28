using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

public class BulletView : View {
    [Inject]
    public IGameModel gameModel { get; set; }
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
        transform.position = Vector3.MoveTowards (transform.position, data.target, data.speed * Time.deltaTime);
        if (Vector3.Distance(data.enemy.transform.position, gameObject.transform.position) < 1f)
        {
            BulletHitEnemySignal.Dispatch(data.enemy);
			Reset();
        } else if (gameObject.transform.position.y <= 0 || gameModel.isGameOver)
        {
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
