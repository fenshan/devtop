using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public static SceneType type;
    public static Scenes scene;

    public GameObject key1;
    public GameObject key2;
    public GameObject key3;

    public PlayerMovement player;

    public GameObject warning;

    private void Start()
    {

        if (PlayerPrefs.HasKey("reset"))
        {
            if (PlayerPrefs.GetInt("reset") == 1)
            {
                warning.SetActive(true);
                PlayerPrefs.SetInt("reset", 0);
            }
            else warning.SetActive(false);
        }
        else warning.SetActive(false);

        type = SceneType.none;
        player = FindObjectOfType<PlayerMovement>();

        key1.SetActive((PlayerPrefs.GetInt("key1") == 1)?true:false);
        key2.SetActive((PlayerPrefs.GetInt("key2") == 1)?true:false);
        key3.SetActive((PlayerPrefs.GetInt("key3") == 1)?true:false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(type.ToString());
            //change scene
            if (type != SceneType.none)
            {
                player.SavePlayerPos();                
                SceneManager.LoadScene(Scenes.SceneName(type));
            }
        }
    }

    public static void ChangeScene(SceneType t, Scenes s)
    {
        if (type != t)
        {
            //Desresaltar la escena que teníamos guardada
            if (type != SceneType.none)
            {
                scene.UnOutline();
            }

            type = t;
            scene = s;

            //Resaltar
            if (t != SceneType.none)
            {
                s.Outline();
            }
        }
    }

    public void CloseWarning()
    {
        warning.SetActive(false);
    }

}
