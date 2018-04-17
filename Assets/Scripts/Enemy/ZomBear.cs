using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZomBear : MonoBehaviour {

	public GameObject player;
	public AudioClip[] footsounds;
	private UnityEngine.AI.NavMeshAgent nav;
	private AudioSource sound;
	private Animator anim;
	private string state = "idle";
	private bool alive = true;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		sound = GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
		nav.speed = 1.2f;
		anim.speed = 1.2f;
	}

	public void footstep(int _num)
	{
		sound.clip = footsounds [_num];
		sound.Play ();
	}

	// Update is called once per frame
	void Update () {
		if (alive == true) {
			
			anim.SetFloat ("velocity", nav.velocity.magnitude);
			//nav.SetDestination (player.transform.position);

			if (state == "idle") {
				//pick random place to walk
				Vector3 randomPos = Random.insideUnitSphere*20f;
				NavMeshHit navHit;
				NavMesh.SamplePosition (transform.position + randomPos, out navHit, 20f, NavMesh.AllAreas);
				nav.SetDestination (navHit.position);
				state = "walk";
			}

			if (state == "walk") {
				if(nav.remainingDistance <= nav.stoppingDistance && !nav.pathPending){
					state = "idle";
				}
			}

		}
	}
}
