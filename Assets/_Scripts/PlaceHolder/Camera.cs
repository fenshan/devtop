using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private float yMax;

    [SerializeField]
    private float yMin;

    [SerializeField]
    private float XMax;

    [SerializeField]
    private float xMin;


    private Transform target;

    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        transform.position = new Vector2(Mathf.Clamp(target.position.x, xMin, XMax), Mathf.Clamp(target.position.y, yMin, yMax));
    }


}
