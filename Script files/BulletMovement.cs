using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.transform.rotation = GameObject.Find("Main Camera").transform.rotation;
        //gameObject.transform.rotation = Quaternion.Euler(GameObject.Find("Person").GetComponent<SettingupClass>().weapons[GameObject.Find("Person").GetComponent<SettingupClass>().classNumber].transform.rotation.x, GameObject.Find("Person").GetComponent<SettingupClass>().weapons[GameObject.Find("Person").GetComponent<SettingupClass>().classNumber].transform.rotation.y, GameObject.Find("Person").GetComponent<SettingupClass>().weapons[GameObject.Find("Person").GetComponent<SettingupClass>().classNumber].transform.rotation.z-90);
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position += transform.forward;
        if (Vector3.Distance(gameObject.transform.position, GameObject.Find("Player II(Clone)").transform.position) > 50) {
            Destroy(gameObject);
        }
	}
    void OnCollisionEnter(Collision other) {
        if(other.transform.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}
