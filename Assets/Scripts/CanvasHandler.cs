using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHandler : MonoBehaviour {

	#if UNITY_STANDALONE
	// Use this for initialization
	void Start () {
		GetComponent<Canvas> ().enabled = false;
	}
	#endif
}
