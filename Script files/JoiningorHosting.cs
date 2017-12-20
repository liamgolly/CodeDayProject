using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JoiningorHosting : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ClickingHost() {
        SceneManager.LoadScene("SelectingMap");

    }
    public void ClickingJoin() {
        SceneManager.LoadScene("SelectingMap");

    }
}
