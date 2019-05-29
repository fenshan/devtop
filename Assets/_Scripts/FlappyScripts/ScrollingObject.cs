using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float scrollSpeed;
    private float groundHorizontalLength;
    private float initialPosition;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(scrollSpeed, 0);
        groundHorizontalLength = GetComponent<BoxCollider2D>().size.x;
        initialPosition = transform.position.x;
    }

    void Update()
    {
        //If true, this means this object is no longer visible and we can safely move it forward to be re-used.
        if (transform.position.x < -groundHorizontalLength + initialPosition)
        {
            transform.position = new Vector2(initialPosition, 0);
        }

        // If the game is over, stop scrolling.
        if (ManagerFlappy.instance.gameOver)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}

