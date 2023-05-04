using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Texture2D defaultCursorTexture;

    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpotMouse = Vector2.zero;


    private void Start()
    {
        Cursor.SetCursor(defaultCursorTexture, hotSpotMouse, cursorMode);
    }
}
