using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public enum Colors { red, orange, yellow, green, cyan, blue, purple, pink, white }

public class ManagerPhotoshop : MonoBehaviour
{
    int currentLevel; //0 none finished; 1 one finished; 2 two finished; 3 three finished
    int currentLayer;//0 none; 1 head; 2 body; 3 legs

    public Sprite[] layerA;
    public Sprite[] layerB;
    public GameObject[] layers;

    public GameObject[] personaje;

    public GameObject winText;
    public GameObject finishText;

    public GameObject[] puzlesModels;

    #region colors
    Color red = new Color(1, 0, 0); //red
    Color orange = new Color(1, 0.56f, 0); //orange
    Color yellow = new Color(1, 1, 0);  //yellow
    Color green = new Color(0.18f, 1, 0);  //green
    Color cyan = new Color(0, 1, 0.9f);  //cyan
    Color blue = new Color(0, 0.18f, 1);  //blue
    Color purple = new Color(0.68f, 0, 1);  //purple
    Color pink = new Color(1, 0, 0.8f);  //pink
    Color white = Color.white;  //pink
    #endregion colors

    private void Start()
    {
        //winText

        if (PlayerPrefs.HasKey("PhotoshopLevel"))
        {
            currentLevel = PlayerPrefs.GetInt("PhotoshopLevel");
        }
        else
        {
            currentLevel = 0;
            PlayerPrefs.SetInt("PhotoshopLevel", 0);
        }
        SetModel(currentLevel);
    }

    bool CheckIfWin()
    {
        if (currentLevel == 3) return false;

        //color and opacity
        Color headColor = personaje[0].GetComponent<Image>().color;
        Color bodyColor = personaje[1].GetComponent<Image>().color;
        Color legsColor = personaje[2].GetComponent<Image>().color;
        //rotation
        float headRotation = Mathf.Round(personaje[0].GetComponent<RectTransform>().rotation.eulerAngles.z);
        float bodyRotation = Mathf.Round(personaje[1].GetComponent<RectTransform>().eulerAngles.z);
        float legsRotation = Mathf.Round(personaje[2].GetComponent<RectTransform>().eulerAngles.z);

        Debug.Log(headRotation + " " + bodyRotation + " " + legsRotation);

        //check if win
        if (currentLevel == 0)
        {
            if (headColor == pink && bodyColor == yellow && legsColor == green &&
                headRotation == 0 && bodyRotation == 0 && legsRotation == 0) //opacidad a tope
                return true;
            else return false;
        }

        else if (currentLevel == 1)
        {
            if (headColor == cyan && bodyColor == purple && legsColor.r == orange.r && legsColor.g == orange.g && legsColor.b == orange.b && legsColor.a == 0.5f &&
                headRotation == 180 && bodyRotation == 0 && legsRotation == 0) //opacidad a tope
                return true;
            else return false;
        }

        else if (currentLevel == 2)
        {
            if (headColor == blue && legsColor == red && bodyColor.r == white.r && bodyColor.g == white.g && bodyColor.b == white.b && bodyColor.a == 0.5f &&
                headRotation == 0 && bodyRotation == 270 && legsRotation == 45) //opacidad a tope
                return true;
            else return false;
        }
        return false;
    }

    void WinLevel()
    {
        ++currentLevel;
        PlayerPrefs.SetInt("PhotoshopLevel", currentLevel);

        //Win animations
        if (currentLevel < 3)
        {
            StartCoroutine(AnimationWinText());
        }

        ResetValuesSolution();

        //Change models
        SetModel(currentLevel);
    }

    public void SetModel(int m)
    {
        Debug.Log(m);

        for (int i = 0; i < puzlesModels.Length; ++i)
        {
            if (i == m) puzlesModels[i].SetActive(true);
            else puzlesModels[i].SetActive(false);
        }

        if (m == 3)
        {
            PlayerPrefs.SetInt("key2", 1);
            finishText.SetActive(true);
        }
        else finishText.SetActive(false);

    }

    IEnumerator AnimationWinText()
    {
        winText.SetActive(true);
        yield return new WaitForSeconds(8f);
        winText.SetActive(false);
    }

    private void ResetValuesSolution()
    {
        foreach (GameObject p in personaje)
        {
            p.GetComponent<Image>().color = Color.white;
            p.GetComponent<RectTransform>().rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    #region buttons
    public void SelectLayerButton(int layer)
    {
        //deseleccionar
        if (currentLayer != 0)
        {
            layers[currentLayer - 1].GetComponent<Image>().sprite = layerA[currentLayer - 1];
        }
        if (currentLayer != layer)
        {
            currentLayer = layer;
            layers[currentLayer - 1].GetComponent<Image>().sprite = layerB[currentLayer - 1];
        }
        else currentLayer = 0;
    }

    public void Rotate()
    {
        if (currentLayer > 0)
        {
            personaje[currentLayer - 1].GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 45));
            if (CheckIfWin())
            {
                WinLevel();
            }
        }
    }

    public void Opacity()
    {
        if (currentLayer > 0)
        {
            Image i = personaje[currentLayer - 1].GetComponent<Image>();
            if (i.color.a == 0) i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
            else if (i.color.a == 0.5f) i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
            else if (i.color.a == 1) i.color = new Color(i.color.r, i.color.g, i.color.b, 0.5f);

            if (CheckIfWin())
            {
                WinLevel();
            }
        }
    }

    public void ChangeColor(int c)
    {
        if (currentLayer > 0)
        {
            Image i = personaje[currentLayer - 1].GetComponent<Image>();
            switch (c)
            {
                case 0: i.color = new Color(1, 1, 1, i.color.a); break; //white
                case 1: i.color = new Color(1, 0, 0, i.color.a); break; //red
                case 2: i.color = new Color(1, 0.56f, 0, i.color.a); break; //orange
                case 3: i.color = new Color(1, 1, 0, i.color.a); break; //yellow
                case 4: i.color = new Color(0.18f, 1, 0, i.color.a); break; //green
                case 5: i.color = new Color(0, 1, 0.9f, i.color.a); break; //cyan
                case 6: i.color = new Color(0, 0.18f, 1, i.color.a); break; //blue
                case 7: i.color = new Color(0.68f, 0, 1, i.color.a); break; //purple
                case 8: i.color = new Color(1, 0, 0.8f, i.color.a); break; //pink
                default: break;
            }

            if (CheckIfWin())
            {
                WinLevel();
            }
        }
    }

    #endregion buttons

}
