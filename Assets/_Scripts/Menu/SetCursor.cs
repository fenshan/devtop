using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursor : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void Start()
    {
        // when we mouse over this object, set the cursor
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
}
