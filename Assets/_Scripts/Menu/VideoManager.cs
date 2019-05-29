using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{
    VideoPlayer vp;

    private void Start()
    {
        vp = GetComponent<VideoPlayer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(Scenes.SceneName(SceneType.Desktop));
        }

        else if (vp.frame >= (long)vp.frameCount - 10)
        {
            SceneManager.LoadScene(Scenes.SceneName(SceneType.Desktop));
        }
    }
}
