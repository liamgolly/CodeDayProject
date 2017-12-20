using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movyyyboi1 : MonoBehaviour {
	public bool hitFirst;
	public float wait;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per 1 frame
	void Update () {
		if (wait < 5) {
			wait += 1 * Time.deltaTime;
		} else {




			if (hitFirst == false) {
				if (Vector3.Distance (new Vector3 (-64, -25, 75), gameObject.transform.position) > 2) {
					gameObject.transform.position += new Vector3 (0, 0, 100) * Time.deltaTime;
		
				} else {
					wait = 0;
					hitFirst = true;
				}
			}
			if (hitFirst == true) {
				if (Vector3.Distance (new Vector3 (-64, -25, 39), gameObject.transform.position) > 2) {
					gameObject.transform.position -= new Vector3 (0, 0, 70) * Time.deltaTime;

				} else {
					wait = 0;
					hitFirst = false;
				}
			}
		}
	}
}