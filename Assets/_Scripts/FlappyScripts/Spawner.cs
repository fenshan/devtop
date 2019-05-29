using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    float rateMin = 1;
    float rateMax = 5;
    float currentRate = 3;
    private float timer = 0;
    public GameObject obstacle;
    public float height;

    // Use this for initialization
    void Start()
    {
        GameObject newSandCastle = Instantiate(obstacle);
        newSandCastle.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > currentRate && !ManagerFlappy.instance.gameOver) 
        {
            GameObject aux = Instantiate(obstacle);
            aux.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            timer = 0;
            currentRate = Random.Range(rateMin, rateMax);
        }
        timer += Time.deltaTime;
    }
}
