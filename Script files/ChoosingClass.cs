using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ChoosingClass : MonoBehaviour {
    public GameObject player;
    public bool hasSelectedClass;
    public GameObject[] Classes = new GameObject[3];
    public Sprite[] WeaponPreviews = new Sprite[3];
	// Use this for initialization
	void Start () {
        hasSelectedClass = false;
	}
	
	// Update is called once per frame
	void Update () {

        GameObject.Find("Selecting Gun").GetComponent<Button>().enabled = hasSelectedClass;
        GameObject.Find("Selecting Gun").GetComponent<Image>().enabled = hasSelectedClass;
        GameObject.Find("Selecting Gun").transform.GetChild(0).GetComponent<Text>().enabled = hasSelectedClass;
    }
    public void Clicking(string bop)
    {
        Debug.Log("yep");
        for(int i = 0; i < Classes.Length; i++)
        {
            Debug.Log(i);
            Debug.Log(Classes[i].transform.name);
            if (bop == Classes[i].transform.name)
            {
                StaticData.classNum = i;
                Debug.Log("yes");
                GameObject.Find("WeaponPreview").GetComponent<Image>().sprite = WeaponPreviews[i];
                hasSelectedClass = true;
                //GameObject.Find("Seleecting Gun").SetActive(hasSelectedClass);
            }
        }
       
    }

    public void StartGameAfterSelectingClass() {
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
        if (GameObject.Find("Map") == true) {
            if (GameObject.Find("WeaponPreview").GetComponent<Image>().sprite == WeaponPreviews[0])
            {
                SceneManager.LoadScene("scene1");
                StaticData.mapPick = 0;
            }
            if(GameObject.Find("WeaponPreview").GetComponent<Image>().sprite == WeaponPreviews[2])
            {
                SceneManager.LoadScene("scene1");
                StaticData.mapPick = 1;
            }
            if (GameObject.Find("WeaponPreview").GetComponent<Image>().sprite == WeaponPreviews[1])
            {
                SceneManager.LoadScene("scene1");
                StaticData.mapPick = 2;
            }
        }else
        {
          
            if(StaticData.mapPick == 0)
            {
                SceneManager.LoadScene("scene2");
            }
            if (StaticData.mapPick == 1)
            {
                SceneManager.LoadScene("Map(t3)1");
            }
            if (StaticData.mapPick == 2)
            {
               
                SceneManager.LoadScene("BunkerHill");
            }
        }

        //Instantiate(player, new Vector3(0, 5, 0), Quaternion.identity);
       // GameObject.Find("FPSController").SetActive(true);
    }
}
