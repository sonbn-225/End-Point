using UnityEngine;
using strange.extensions.mediation.impl;
using DG.Tweening;

public class EnemyView : View, IDestroyable {

    public Vector3 Velocity { get; internal set; }
	private Transform player;
	private NavMeshAgent nav;

    public void Destroy() {
        Destroy(gameObject);
    }

    protected override void Start() {
        base.Start();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent<NavMeshAgent> ();
    }

    private void Update () {
		nav.SetDestination (player.position);
    }
}
