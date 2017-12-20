using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingupClass : MonoBehaviour {
    public int classNumber;
    public GameObject[] weapons = new GameObject[3];
    public Vector3[] weaponLocalPostions = new Vector3[3];

    public bool hasaClass;
    // Use this for initialization
    void Start()
    {
        classNumber = StaticData.classNum;
        //oof
        hasaClass = false;


        for (int i = 0; i < weapons.Length; i ++)
        {
            if (hasaClass == false) { 
            Debug.Log(classNumber + "==" + i);
            if (classNumber == i)
            {
                weapons[i].transform.localPosition = weaponLocalPostions[i];
                hasaClass = true;
                    weapons[i].GetComponent<Firing>().enabled = false;
                }
            else
            {
                Debug.Log("set");
                weapons[i].transform.localPosition = new Vector3(0, -50, 0);
                weapons[i].GetComponent<Firing>().enabled = false;
            }
           
            }else
            {
                Debug.Log("set");
                weapons[i].transform.localPosition = new Vector3(0, -50, 0);
                weapons[i].GetComponent<Firing>().enabled = false;
            }
    }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
