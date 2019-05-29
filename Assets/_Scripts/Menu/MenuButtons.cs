using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void StartButton()
    {
        //RESET VALUES
        PlayerMovement.ResetPlayerPos();
        PlayerPrefs.SetInt("key1", 0);
        PlayerPrefs.SetInt("key2", 0);
        PlayerPrefs.SetInt("key3", 0);
        PlayerPrefs.SetInt("PhotoshopLevel", 0);
        PlayerPrefs.SetInt("reset", 1);

        SceneManager.LoadScene(Scenes.SceneName(SceneType.VideoIntro)); 
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene(Scenes.SceneName(SceneType.Credits)); 
    }

    public void HowToPlayButton()
    {
        SceneManager.LoadScene(Scenes.SceneName(SceneType.HowToPlay)); 
    }

    public void ExitButton()
    {
        Application.Quit();
    }



}
