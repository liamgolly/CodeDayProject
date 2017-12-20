using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour
{

    void Update()
    {
        transform.LookAt(GameObject.Find("Main Camera").transform.position);
    }
}