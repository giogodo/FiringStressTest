using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField]
	private float lifespan;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifespan);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D target) {
		if (target.gameObject.tag == "Bullet") {
			_GameManager.instance.AddScore (1);
			Destroy (gameObject); //Destroy itself
		}
	}
}
