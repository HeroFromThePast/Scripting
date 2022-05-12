using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DragAndDrop : MonoBehaviour
{
    Vector3 dragOffset;
    Camera cam;
    public event Action OnClickedDone;
    private void Awake()
    {
        cam = Camera.main;
    }

    private void OnMouseDown()
    {
        OnClickedDone?.Invoke();
        dragOffset = transform.position - GetMousePos();
        Player.instance.enemyKilled = false;
    }

    private void OnMouseUp()
    {
        Player.instance.ReturnToTower();
    }

    private void OnMouseDrag()
    {
        if(!Player.instance.enemyKilled)
            transform.position = GetMousePos() + dragOffset;
    }

    Vector3 GetMousePos()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }
}
