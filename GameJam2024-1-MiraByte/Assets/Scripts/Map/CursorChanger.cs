using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    public Texture2D baseCursor;
    public Texture2D hoverCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    private void Start()
    {
        SetBaseCursor();
    }
    public void SetHoverCursor()
    {
        Cursor.SetCursor(hoverCursor, hotSpot, cursorMode);
    }

    public void SetBaseCursor()
    {
        Cursor.SetCursor(baseCursor, hotSpot, cursorMode);
    }
}
