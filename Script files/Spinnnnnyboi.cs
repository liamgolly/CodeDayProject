using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinnnnnyboi : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.eulerAngles = new Vector3 (0, gameObject.transform.eulerAngles.y + 1440 * Time.deltaTime, 0);
	}
}
