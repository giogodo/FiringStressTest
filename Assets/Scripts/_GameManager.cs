using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _GameManager : MonoBehaviour {
	public static _GameManager instance;
	private int score;
	[SerializeField]
	private Transform enemies;
	[SerializeField]
	private Enemy enemy;
	[SerializeField]
	private Enemy darkEnemy;
	private GUIStyle guiStyle = new GUIStyle ();

	void Awake () {
		instance = this;
	}

	// Use this for initialization
	void Start () {
		score = 0;
		guiStyle.fontSize = 45;
		// Temp
		InvokeRepeating("CreateEnemy", 0f, 3f);
		InvokeRepeating("CreateDarkEnemy", 1.5f, 3f);
	}

	#if UNITY_ANDROID

	public void RaiseCreateEnemy () {
		InvokeRepeating("CreateEnemy", 0f, 3f);
	}

	public void RaiseCreateDarkEnemy () {
		InvokeRepeating("CreateDarkEnemy", 1.5f, 3f);
	}

	public void DropCreateEnemy () {
		CancelInvoke ("CreateEnemy");
	}

	public void DropCreateDarkEnemy () {
		CancelInvoke ("CreateDarkEnemy");
	}

	#elif UNITY_STANDALONE

	// Update is called once per frame
	void Update () {
	// Activating-Deactivating dark and normal enemies
	if (Input.GetKey(KeyCode.U)) {
			CancelInvoke ("CreateEnemy");
		}
		if (Input.GetKey(KeyCode.I)) {
			CancelInvoke ("CreateDarkEnemy");
		}
		if (Input.GetKeyUp(KeyCode.O)) {
			InvokeRepeating("CreateEnemy", 0f, 3f);
		}
		if (Input.GetKeyUp(KeyCode.P)) {
			InvokeRepeating("CreateDarkEnemy", 1.5f, 3f);
		}
	}

	#endif

	public void AddScore (int addScore) {
		score += addScore;
	}

	public void CreateEnemy () {
		Enemy newEnemy = Instantiate (enemy, enemies) as Enemy;
		newEnemy.transform.Translate (Random.Range(-8.2f, 8.2f),0,0);
	}

	public void CreateDarkEnemy () {
		Enemy newEnemy = Instantiate (darkEnemy , enemies) as Enemy;
		newEnemy.transform.Translate (Random.Range(-8.2f, 8.2f),0,0);
	}

	void OnGUI () {
		GUI.Label (new Rect (10, 10, 100, 100), "Score: " + score, guiStyle);
	}
}
