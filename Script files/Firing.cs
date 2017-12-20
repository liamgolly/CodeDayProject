using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Firing : NetworkBehaviour
{
    public int magazine;
    public int magazineSize;
    public int reserve;
    public int waitFactor;
    public int FireRateWait;
    public bool o = false;
    public GameObject Bullet;

    public int[] negativePos = new int[3];
    // Use this for initialization
    void Start()
    {
        if (gameObject.transform.name == "Player II(Clone)")
        {
            magazine = transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.GetComponent<Firing>().magazine;
            reserve = transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.GetComponent<Firing>().reserve;
            magazineSize = transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.GetComponent<Firing>().magazineSize;
            FireRateWait = transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.GetComponent<Firing>().FireRateWait;
        }
    }
    void OnGUI() {
        GUIStyle style = new GUIStyle();
        style.fontSize = 50;
        style.normal.textColor = Color.blue;
        GUI.Label(new Rect(Screen.width - 150, Screen.height - 100, 50, 50), magazine + "/" + reserve,style);
    }
    void Update() {
        if (waitFactor < FireRateWait)
        {
            waitFactor++;
        }
       
            CmdUpdate();
        
    }
    // Update is called once per frame
    [Command]
    void CmdUpdate()
    {
        if (transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.tag == "semi")
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.tag == "semi")
                {
                    if (waitFactor >= FireRateWait && magazine > 0)
                    {
                        var Fire = (GameObject)Instantiate(Bullet, GameObject.Find("BulletSpawn").transform.position, Quaternion.identity);
                        NetworkServer.Spawn(Fire);
                        waitFactor = 0;
                        magazine--;
                    }
                }
            }
        }

        if (transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.tag == "auto")
        {
            if (Input.GetMouseButton(0))
            {
                if (transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.tag == "auto")
                {
                    if (waitFactor >= FireRateWait && magazine > 0)
                    {
                        var Fire = (GameObject)Instantiate(Bullet, GameObject.Find("BulletSpawn").transform.position, Quaternion.identity);
                        NetworkServer.Spawn(Fire);
                        waitFactor = 0;
                        magazine--;
                    }
                }
            }
        }
        if(magazine <= 0)
        {
            if (transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.tag == "auto")
            {
                {
                    if (Quaternion.Angle(transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.localRotation, Quaternion.Euler(-28, transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.localEulerAngles.y, 0)) > 3 && o == false)
                    {

                        Debug.Log(Quaternion.Angle(transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.localRotation, Quaternion.Euler(-28, 0, 0)));
                        transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.localRotation = Quaternion.Slerp(transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.localRotation, Quaternion.Euler(-30, transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.localEulerAngles.y, 0), Time.deltaTime * 2);

                    }
                    else
                    {

                        Debug.Log("Done");
                        if (transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.GetChild(0).transform.localPosition.y > (negativePos[GameObject.Find("Player II(Clone)").GetComponent<SettingupClass>().classNumber]) && o == false)
                        {

                            transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.GetChild(0).transform.localPosition = Vector3.Lerp(transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.GetChild(0).transform.localPosition, new Vector3(transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.GetChild(0).transform.localPosition.x, negativePos[GameObject.Find("Player II(Clone)").GetComponent<SettingupClass>().classNumber], transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.GetChild(0).transform.localPosition.z), Time.deltaTime * 3);
                        }
                        else
                        {
                            o = true;
                            if (transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.GetChild(0).transform.localPosition.y < -2)
                            {

                                transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.GetChild(0).transform.localPosition = Vector3.Lerp(transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.GetChild(0).transform.localPosition, new Vector3(transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.GetChild(0).transform.localPosition.x, 0, transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.GetChild(0).transform.localPosition.z), Time.deltaTime * 5);
                            }
                            else
                            {

                                Debug.Log(Quaternion.Angle(transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.localRotation, Quaternion.Euler(0, 0, 0)));
                                transform.GetChild(GetComponent<SettingupClass>().classNumber + 1).transform.localRotation = Quaternion.Euler(0, 0, 0);

                                if (reserve > magazineSize)
                                {
                                    o = false;
                                    magazine = magazineSize;
                                    reserve -= magazineSize;
                                }
                                else
                                {
                                    o = false;
                                    magazine = reserve;
                                    reserve = 0;

                                }
                            }
                        }
                    }
                }
            }
        }
        




        if (gameObject.transform.tag == "auto")
            {
                if (waitFactor < FireRateWait)
                {
                    waitFactor++;
                }
                if (magazine > 0)
                {
                    if (Input.GetMouseButton(0) && waitFactor >= FireRateWait)
                    {
                        Instantiate(Bullet, gameObject.transform.GetChild(1).transform.position, Quaternion.identity);
                    NetworkServer.Spawn(Bullet);
                        magazine--;
                        waitFactor = 0;
                    }
                }
            
            else
            {
                if (Quaternion.Angle(gameObject.transform.localRotation, Quaternion.Euler(-28, gameObject.transform.localEulerAngles.y, 0)) > 3 && o == false)
                {

                    Debug.Log(Quaternion.Angle(gameObject.transform.localRotation, Quaternion.Euler(-28, -90, 0)));
                    gameObject.transform.localRotation = Quaternion.Slerp(gameObject.transform.localRotation, Quaternion.Euler(-30, gameObject.transform.localEulerAngles.y, 0), Time.deltaTime * 2);

                }
                else
                {

                    Debug.Log("Done");
                    if (gameObject.transform.GetChild(0).transform.localPosition.y > (negativePos[GameObject.Find("Player II(Clone)").GetComponent<SettingupClass>().classNumber] + 5) && o == false)
                    {

                        gameObject.transform.GetChild(0).transform.localPosition = Vector3.Lerp(gameObject.transform.GetChild(0).transform.localPosition, new Vector3(gameObject.transform.GetChild(0).transform.localPosition.x, negativePos[GameObject.Find("Player II(Clone)").GetComponent<SettingupClass>().classNumber], gameObject.transform.GetChild(0).transform.localPosition.z), Time.deltaTime * 3);
                    }
                    else
                    {
                        o = true;
                        if (gameObject.transform.GetChild(0).transform.localPosition.y < -2)
                        {

                            gameObject.transform.GetChild(0).transform.localPosition = Vector3.Lerp(gameObject.transform.GetChild(0).transform.localPosition, new Vector3(gameObject.transform.GetChild(0).transform.localPosition.x, 0, gameObject.transform.GetChild(0).transform.localPosition.z), Time.deltaTime * 5);
                        }
                        else
                        {

                            Debug.Log(Quaternion.Angle(gameObject.transform.localRotation, Quaternion.Euler(0, 0, 0)));
                            gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);

                            if (reserve > magazineSize)
                            {
                                o = false;
                                magazine = magazineSize;
                                reserve -= magazineSize;
                            }
                            else
                            {
                                o = false;
                                magazine = reserve;
                                reserve = 0;

                            }
                        }
                    }
                }
            }
        }
            if (gameObject.transform.tag == "semi")
            {
                if (magazine > 0)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                    NetworkServer.Spawn(Bullet);
                    Instantiate(Bullet, gameObject.transform.GetChild(1).transform.position, Quaternion.identity);
                        magazine--;
                    }
                }
                else
                {
                    if (Quaternion.Angle(gameObject.transform.localRotation, Quaternion.Euler(-28, 90, 0)) > 3 && o == false)
                    {

                        Debug.Log(Quaternion.Angle(gameObject.transform.localRotation, Quaternion.Euler(-28, 180, 0)));
                        gameObject.transform.localRotation = Quaternion.Slerp(gameObject.transform.localRotation, Quaternion.Euler(-30, gameObject.transform.localEulerAngles.y, 0), Time.deltaTime * 2);

                    }
                    else
                    {

                        Debug.Log("Done");
                        if (gameObject.transform.GetChild(0).transform.localPosition.y < (negativePos[GameObject.Find("Player II(Clone)").GetComponent<SettingupClass>().classNumber])-.1f && o == false)
                        {

                            gameObject.transform.GetChild(0).transform.localPosition = Vector3.Lerp(gameObject.transform.GetChild(0).transform.localPosition, new Vector3(gameObject.transform.GetChild(0).transform.localPosition.x, negativePos[GameObject.Find("Player II(Clone)").GetComponent<SettingupClass>().classNumber], gameObject.transform.GetChild(0).transform.localPosition.z), Time.deltaTime);
                        }
                        else
                        {
                            o = true;
                            if (gameObject.transform.GetChild(0).transform.localPosition.y > 0+.01f)
                            {

                                gameObject.transform.GetChild(0).transform.localPosition = Vector3.Lerp(gameObject.transform.GetChild(0).transform.localPosition, new Vector3(gameObject.transform.GetChild(0).transform.localPosition.x, 0, gameObject.transform.GetChild(0).transform.localPosition.z), Time.deltaTime * 5);
                            }
                            else
                            {

                                Debug.Log(Quaternion.Angle(gameObject.transform.localRotation, Quaternion.Euler(0, 90, 0)));
                                gameObject.transform.localRotation = Quaternion.Euler(0, 90, 0);

                                if (reserve > magazineSize)
                                {
                                o = false;
                                    magazine = magazineSize;
                                    reserve -= magazineSize;
                                }
                                else
                                {
                                o = false;
                                    magazine = reserve;
                                    reserve = 0;

                                }
                            }
                        }
                    }
                }
            }

        }
    }
