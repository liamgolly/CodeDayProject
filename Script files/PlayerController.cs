using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {
    public int health;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer) {
            return;
        }
        GameObject.Find("Main Camera").transform.position = gameObject.transform.position;
        GameObject.Find("Visor").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("Main Camera").transform.rotation = Quaternion.Euler(gameObject.transform.eulerAngles.x,gameObject.transform.eulerAngles.y+90,gameObject.transform.eulerAngles.z);

        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 10f;

        transform.Rotate(0, x, 0);
        transform.Translate(z, 0, 0);
	}
    void OnCollisionEnter(Collision other) {
        if(other.transform.tag == "Bullet")
        {
            health -= 10;
            Destroy(other.gameObject);
        }
    }
    void OnGUI() {

    }
}
