using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneType { Menu, Desktop, Photoshop, Programming, Audio, Zambomba, FlappyFlipFlop, Placeholder, none, VideoIntro,HowToPlay, Credits }

public class Scenes : MonoBehaviour
{
    public SceneType type;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GoToScene.ChangeScene(type, this);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GoToScene.ChangeScene(SceneType.none, this);
        }
    }

    public void Outline()
    {
        GameObject s = new GameObject();
        s.AddComponent<SpriteRenderer>();
        s.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
        s.transform.SetParent(transform, false);
        s.transform.localScale = new Vector2(1.2f, 1.2f);
        s.name = "Outline";
    }

    public void UnOutline()
    {
        Debug.Log("dddd");
        Destroy(transform.Find("Outline").gameObject);
    }

    public static string SceneName(SceneType s)
    {
        switch (s)
        {
            case SceneType.Menu: return "_Menu";
            case SceneType.Desktop: return "Desktop";
            case SceneType.Photoshop: return "Photoshop";
            case SceneType.Programming: return "Programming";
            case SceneType.Audio: return "Audio";
            case SceneType.Zambomba: return "Zambomba";
            case SceneType.FlappyFlipFlop: return "FlappyBird";
            case SceneType.Placeholder: return "Placeholder";
            case SceneType.VideoIntro: return "VideoIntro";
            case SceneType.Credits: return "Credits";
            case SceneType.HowToPlay: return "HowToPlay";
            default: return "";

        }
    }

    public static SceneType Type(string n)
    {
        switch (n)
        {
            case "_Menu": return SceneType.Menu;
            case "Desktop": return SceneType.Desktop;
            case "Photoshop": return SceneType.Photoshop;
            case "Programming": return SceneType.Programming;
            case "Audio": return SceneType.Audio;
            case "Zambomba": return SceneType.Zambomba;
            case "FlappyBird": return SceneType.FlappyFlipFlop;
            case "Placeholder": return SceneType.Placeholder;
            case "VideoIntro": return SceneType.VideoIntro;
            case "Credits": return SceneType.Credits;
            case "HowToPlay": return SceneType.HowToPlay;

            default: return SceneType.none;

        }
    }

}