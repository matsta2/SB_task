using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using Vector3 = UnityEngine.Vector3;
using System.Runtime.InteropServices;
using UnityEngine.UI;

public class ObjectMove : MonoBehaviour
{
    private Vector3 _dragOffset;
    private Camera _cam;
    [SerializeField] private float _speed = 1000;

    private void Awake()
    {
        _cam = Camera.main;
    }

    private void OnMouseDown()
    {
        _dragOffset = transform.position - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
    }

    Vector3 GetMousePos()
    {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.y = transform.position.y;
        return mousePos;
    }
    
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);
    
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            int xPos = 1200, yPos = 600;
            // int xPos = Screen.height /2;
            // int yPos = Screen.width /2;
            SetCursorPos(xPos,yPos);
        }
    }
}