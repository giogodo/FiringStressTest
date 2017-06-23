using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	#if UNITY_ANDROID

	private JoystickHandler joystick;
	private Guns guns;
	private float angle;

	void Awake () {
		guns = GetComponentInChildren<Guns> ();
	}

	// Use this for initialization
	void Start () {
		joystick = GameObject.Find ("Canvas/Joystick").GetComponent<JoystickHandler> ();
	}

	// Update is called once per frame
	void Update () {
		// Getting player direction
		angle = transform.rotation.eulerAngles.z;
		// Getting direction for the shoot
		guns.shootingDirection = new Vector3 (-Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle), 0);
		// Changing player direction
		/*transform.rotation = Quaternion.Euler(0f, 0f, -joystick.inputAngle);*/
		if (joystick.inputDirection.x < 0) {
			transform.Rotate (0,0,2.5f);
		} else if (joystick.inputDirection.x > 0) {
			transform.Rotate(0,0,-2.5f);
		}
	}

	public void StartShooting () {
		guns.isShooting = true;
		// Sending direction for the shoot
		guns.shootingDirection = new Vector3 (-Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle), 0);
	}

	public void StopShooting () {
		guns.isShooting = false;
	}

	#elif UNITY_STANDALONE

	private Guns guns;
	private float angle;

	void Awake () {
		guns = GetComponentInChildren<Guns> ();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		// Getting player direction
		angle = transform.rotation.eulerAngles.z;
		//Capture shooting
		if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) {
			guns.isShooting = true;
			// Sending direction for the shoot
			guns.shootingDirection = new Vector3 (-Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle), 0);
		} else {
			guns.isShooting = false;
		}
		// Changing player direction
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.Rotate (0,0,2.5f);
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			transform.Rotate(0,0,-2.5f);
		}
	}

	#endif
}
