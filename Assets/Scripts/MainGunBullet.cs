using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGunBullet : MonoBehaviour {
	[HideInInspector]
	public float velocity;
	[HideInInspector]
	public float lifespan;
	[HideInInspector]
	public Vector3 direction;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifespan);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (direction * velocity * Time.deltaTime, Space.World); //Bullet movement
	}

	void OnCollisionEnter2D (Collision2D target) {
		if (target.gameObject.tag == "Enemy") {
			Destroy (gameObject); //Destroy the bullet
			//Destroy (target.gameObject); //Destroy the target
		}
	}
}
