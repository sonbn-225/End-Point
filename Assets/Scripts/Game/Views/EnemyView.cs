using UnityEngine;
using strange.extensions.mediation.impl;
using DG.Tweening;

public class EnemyView : View, IDestroyable {

    public Vector3 Velocity { get; internal set; }
	private Transform player;
	private float speed = 2f;

    public void Destroy() {
        Destroy(gameObject);
    }

    protected override void Start() {
        base.Start();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
    }

    private void Update () {
		transform.position = Vector3.MoveTowards (transform.position, player.position, speed * Time.deltaTime);
    }
}
