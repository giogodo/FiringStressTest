using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour {
	[HideInInspector]
	public Vector3 shootingDirection;
	[HideInInspector]
	public bool isShooting;
	[HideInInspector]
	public int gunSelected = 0;
	//variables for main gun
	[SerializeField]
	private MainGunBullet mainGunBullet;
	[SerializeField]
	private float mainGunBulletVelocity;
	[SerializeField]
	private float mainGunCooldown;
	[SerializeField]
	private float mainGunLifespan;
	[HideInInspector]
	public float mainGunCooldownRemaining; // Public for state bars
	[SerializeField]
	private Transform mainGunMuzzle;
	// Use this for initialization
	void Start () {
		mainGunCooldownRemaining = 0f;
		isShooting = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isShooting) {
			switch (gunSelected) {
			case 0:
				MainGunShooting ();
				break;
			default:
				break;
			}	
		}
	}

	// Main gun
	void MainGunShooting () {
		mainGunCooldownRemaining -= Time.deltaTime;
		if (mainGunCooldownRemaining <= 0) {
			mainGunCooldownRemaining = mainGunCooldown;
			MainGunBullet newMainGunBullet = Instantiate (mainGunBullet, mainGunMuzzle.position, mainGunMuzzle.rotation) as MainGunBullet;
			newMainGunBullet.velocity = mainGunBulletVelocity;
			newMainGunBullet.lifespan = mainGunLifespan;
			newMainGunBullet.direction = shootingDirection;
		}
	}
}
