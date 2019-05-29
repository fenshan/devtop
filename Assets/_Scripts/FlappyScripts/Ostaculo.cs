using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ostaculo : MonoBehaviour
{
    public float speed = 3;

    void Update()
    {
        if (!ManagerFlappy.instance.gameOver)
            transform.position += Vector3.left * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "limiteFlappy")
        {
            Destroy(gameObject);
        }

        else if (collision.tag == "Chancla")
        {
            ManagerFlappy.instance.Lose();
        }
    }
}


