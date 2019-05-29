using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPlaceHolder : MonoBehaviour
{
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;

    public bool hasKey1;
    public bool hasKey2;
    public bool hasKey3;

    // Start is called before the first frame update
    void Start()
    {
        hasKey1 = PlayerPrefs.GetInt("key1") == 1 ? true : false;
        hasKey2 = PlayerPrefs.GetInt("key2") == 1 ? true : false;
        hasKey3 = PlayerPrefs.GetInt("key3") == 1 ? true : false;
        
        key1.SetActive(hasKey1);
        key2.SetActive(hasKey2);
        key3.SetActive(hasKey3);




    }

}
