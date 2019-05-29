using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player
    : MonoBehaviour
{
    public Vector2Int direction;
    public int xPos;
    public int yPos;
    public int col;
    public int row;
    public bool hasKey = false;
    public bool doorIsOpen = false;

    public GameObject winText;

    void Start()
    {
        xPos = 1;
        yPos = 5;
        //xPos = 10;
        //yPos = 3;
        ActualizarPosPlayer();
        if (PlayerPrefs.HasKey("key3"))
        {
            winText.SetActive((PlayerPrefs.GetInt("key3") == 1)?true:false);
        }
    }

    void ActualizarPosPlayer()
    {
        transform.position = new Vector2(xPos, yPos);
    }


    public void Move(int i, int j)
    {
        direction.x = i;
        direction.y = j;
        col = xPos + i;
        row = yPos + j;

        bool win;
        if (AttemptMove(col, row, out win))
        {
            xPos = col;
            yPos = row;
            ActualizarPosPlayer();

            //si ha ganado
            if (win)
            {
                //TODO PANTALLA DE GANAR
                PlayerPrefs.SetInt("key3", 1);
                Debug.Log("HAS GANADO :D");
                winText.SetActive(true);
            }

        }


        //Si no se puede mover: ERROR TODO
        else
        {
            Debug.Log("cant");

        }


    }

    public bool AttemptMove(int col, int row, out bool win)
    {
        //foreach(Tyle t in Boardmanager.Instance.board)
        //{
        //    Debug.Log(t.Type.ToString());
        //}

        Debug.Log(col + " " + row);

        win = false;

        if (Boardmanager.Instance.board[col, row].Type == Tyle.TileType.Floor)
        {
            return true;
        }

        else if (Boardmanager.Instance.board[col, row].Type == Tyle.TileType.Door && doorIsOpen)
        {
            return true;
        }

        else if (Boardmanager.Instance.board[col, row].Type == Tyle.TileType.Goal)
        {
            win = true;
            return true;
        }

        return false;
    }

    public void Interact()
    {
        Debug.Log("interact");
        col = xPos + direction.x;
        row = yPos + direction.y;

        if (Boardmanager.Instance.board[col, row].Type == Tyle.TileType.Key)
        {
            hasKey = true;
            Boardmanager.Instance.ConvertTyle(col, row, Tyle.TileType.Floor);
        }
        else if (Boardmanager.Instance.board[col, row].Type == Tyle.TileType.ClosedPath)
        {
            if (hasKey)
            {
                Boardmanager.Instance.ConvertTyle(col, row, Tyle.TileType.Floor);
            }
        }
        else if (Boardmanager.Instance.board[col, row].Type == Tyle.TileType.Box)
        {
            if (Boardmanager.Instance.board[col + direction.x, row + direction.y].Type == Tyle.TileType.Floor)
            {
                Boardmanager.Instance.ConvertTyle(col + direction.x, row + direction.y, Tyle.TileType.Box);
                Boardmanager.Instance.ConvertTyle(col, row, Tyle.TileType.Floor);
            }

            else if (Boardmanager.Instance.board[col + direction.x, row + direction.y].Type == Tyle.TileType.Button)
            {
                //si he peusto la caja encima del boton, la puerta se abre. No funciona en caso de que se pueda quitar la caja del botón una vez puesta encima

                //Abrir la puerta
                doorIsOpen = true;
                Boardmanager.Instance.OpenDoor();

                Boardmanager.Instance.ConvertTyle(col + direction.x, row + direction.y, Tyle.TileType.Box);
                Boardmanager.Instance.ConvertTyle(col, row, Tyle.TileType.Floor);
            }
        }
    }
}
