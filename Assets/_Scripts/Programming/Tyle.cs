using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tyle : MonoBehaviour
{
    public enum TileType { Floor, Wall, Bomb, Key, Box, ClosedPath, Button, Door, Goal }

    public TileType Type;
    
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Boardmanager.Instance.GetTileAt();
    }
}
