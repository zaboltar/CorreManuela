using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatormDestroyer : MonoBehaviour {

	public GameObject platformDestrPoint;



	// Use this for initialization
	void Start () {
		platformDestrPoint = GameObject.Find ("PlatformDestrPoint");
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < platformDestrPoint.transform.position.x) {
			//Destroy(gameObject);

			gameObject.SetActive(false);
		}
	}
}
