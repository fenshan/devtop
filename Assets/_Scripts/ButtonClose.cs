using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClose : MonoBehaviour
{
   public void Close()
    {
        if (Scenes.Type(SceneManager.GetActiveScene().name) == SceneType.Placeholder)
        {
            FindObjectOfType<PlayerMovement>().SavePlayerPos();
        }
        SceneManager.LoadScene(Scenes.SceneName(SceneType.Desktop));
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(Scenes.SceneName(SceneType.Menu));
    }

}
