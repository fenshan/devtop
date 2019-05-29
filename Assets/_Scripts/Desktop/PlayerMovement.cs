using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    /*
     
         SET ON PROJECT SETTINGS -> INPUT
         jump -> space
         right -> d
         left -> a
         
         */
    public ManagerPlaceHolder Mph;
    private float speed;
    private float jumpForce;
    private Rigidbody2D rb;
    private Animator anim;
    private SceneType scene;
    public GameObject[] Warning;
   

    void Start()
    {
        scene = Scenes.Type(SceneManager.GetActiveScene().name);

        anim = GetComponentInChildren<Animator>();
        if (PlayerPrefs.HasKey("PlayerX" + scene) && PlayerPrefs.HasKey("PlayerY" + scene))
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("PlayerX" + scene), PlayerPrefs.GetFloat("PlayerY" + scene));
            //Debug.Log("load " + transform.position.x + " " + transform.position.y);

        }
        rb = GetComponent<Rigidbody2D>();
        speed = 3;
        jumpForce = 300f;

        foreach (GameObject w in Warning)
        {
            w.SetActive(false);
        }
    }

    public void SavePlayerPos()
    {
        PlayerPrefs.SetFloat("PlayerX" + scene, transform.position.x);
        PlayerPrefs.SetFloat("PlayerY" + scene, transform.position.y);
        //Debug.Log("save " + transform.position.x + " " + transform.position.y);
    }

    public static void ResetPlayerPos()
    {
        string d = Scenes.SceneName(SceneType.Desktop);
        string p = Scenes.SceneName(SceneType.Placeholder);

        string[] names = { "PlayerX" + p, "PlayerX" + d, "PlayerY" + p, "PlayerY" + d };

        foreach (string s in names)
        {
            if (PlayerPrefs.HasKey(s))
            {
                PlayerPrefs.DeleteKey(s);
            }
        }
    }


    void FixedUpdate()
    {
        //jump
        bool grounded = false;
        RaycastHit2D hit = Physics2D.Linecast(transform.position, transform.position + Vector3.down * 0.4f, 1 << LayerMask.NameToLayer("Default")); //TODO coger la mitad de la altura de la y del collider
        if (hit.collider != null) grounded = true;
        //Debug.DrawLine(transform.position, transform.position + Vector3.down * 100, Color.red);

        if (Input.GetButtonDown("jump") && grounded)
        {
            //Debug.Log("YA!!");
            //TODO animación de saltar
            rb.AddForce(new Vector2(0f, jumpForce));
        }

        //left right
        float moveHorizontal;
        bool right = false;
        if (Input.GetButton("right")) right = true;
        if (Input.GetButton("left")) moveHorizontal = (right) ? 0 : -1;
        else moveHorizontal = (right) ? 1 : 0;

        //Debug.Log(moveHorizontal);

        anim.SetFloat("Speed", moveHorizontal);
        Vector2 movement = new Vector2(moveHorizontal * speed, rb.velocity.y);

        rb.velocity = movement;
        //rb.AddForce(movement * speed);
    }

    public void OnCollisionEnter2D(Collision2D col)

    {
        if (col.gameObject.tag == "Obstacle1")
        {
            
            if (Mph.hasKey1 == true)
            {
                Destroy(col.gameObject);
            }
            else
            {
                Warning[0].SetActive(true);
            }

        }
        else if (col.gameObject.tag == "Obstacle2")
        {
            
            if (Mph.hasKey2 == true)
            {
                Destroy(col.gameObject);
            }
            else
            {
                Warning[1].SetActive(true);
            }

        }
        else if (col.gameObject.tag == "Obstacle3")
        {
            
            if (Mph.hasKey3 == true)
            {
                Destroy(col.gameObject);
            }
            else
            {
                Warning[2].SetActive(true);
            }
        }
    }

    public void CloseWarning(int warningNumber)
    {
        Warning[warningNumber].SetActive(false);
    }
}
