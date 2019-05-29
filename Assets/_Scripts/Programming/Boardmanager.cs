using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boardmanager : MonoBehaviour
{
    #region Singleton

    private static Boardmanager instance;
    public static Boardmanager Instance
    {
        get
        {
            return instance;
        }
        private set
        {
            instance = value;
        }
    }

    #endregion Singleton

    [Header("Set in code")]
    public Tyle[,] board;
    public const int dimX = 16;
    public const int dimY = 7;

    //Posicion elementos importantes
    public Vector2Int metaPos;
    public Vector2Int puertaPos;

    [Header("Set in inspector")]
    public GameObject floorParent;
    public GameObject specialParent;
    public Tyle [] prefabs;
    
    public Sprite puertaAbierta;
       

    void Awake() 
    {

        if ((instance != null) && (instance != this)) // Comprubea si instance no es nulo, Si lo no es, comprubea si instance es igual al boardmanager actual. Si no lo es, destruye el instance
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        Tyle[] casillas = FindObjectsOfType<Tyle>(); //Crea un array donde se guardan todos los objetos del tipo casilla

        board = new Tyle[dimX, dimY]; //Crea el array de dos dimensiones donde se formara el tablero
        for (int i = 0; i < casillas.Length; i++)
        {
            int fila = (int)casillas[i].transform.position.y;

            int columna = (int)casillas[i].transform.position.x;

            board[columna, fila] = casillas[i];

            //Set puertaPos and metaPos
            if (casillas[i].Type == Tyle.TileType.Goal)
            {
                metaPos = new Vector2Int(columna, fila);
            }
            else if (casillas[i].Type == Tyle.TileType.Door)
            {
                puertaPos = new Vector2Int(columna, fila);
            }

        }
    }

    public Tyle GetTileAt(int row, int col)
    {
        return board[col, row];
    }


    public void ConvertTyle(int i, int j, Tyle.TileType t)
    {
        Debug.Log("destroy " + board[i, j].Type.ToString());
        Destroy(board[i, j].gameObject);

        Tyle aux = null;

        switch (t)
        {
            case Tyle.TileType.Floor:
                aux = Instantiate(prefabs[0]);
                aux.transform.SetParent(floorParent.transform, false);
                break;
            case Tyle.TileType.Box:
                aux = Instantiate(prefabs[1]);
                aux.transform.SetParent(specialParent.transform, false);
                break;
            default: break;
        }

        aux.transform.position = new Vector2(i, j);
        board[i, j] = aux;
    }

    public void OpenDoor ()
    {
        board[puertaPos.x, puertaPos.y].GetComponent<SpriteRenderer>().sprite = puertaAbierta;
    }

}
