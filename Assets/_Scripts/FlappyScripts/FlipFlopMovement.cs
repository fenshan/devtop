using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipFlopMovement : MonoBehaviour
{
    float velocity;
    Rigidbody2D rb;

    void Start()
    {
        ResetPosition();
        velocity = 4;
        rb = GetComponent<Rigidbody2D>();
    }

    public void ResetPosition()
    {
        transform.position = new Vector2(-7, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !ManagerFlappy.instance.gameOver)
        {
            //jump
            //rb.AddForce(Vector2.up * velocity);
            rb.velocity = Vector2.up * velocity;
        }

    }


}
