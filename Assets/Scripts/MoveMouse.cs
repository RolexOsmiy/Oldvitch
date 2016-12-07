using UnityEngine;
using System.Collections;

public class MoveMouse : MonoBehaviour
{
    public GameObject cam;
    public float cursorLastPosX;
    public float cursorLastPosY;

    void Start()
    {
        cam = GameObject.Find("Camera").gameObject;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        cam.transform.Rotate(cursorLastPosY - Input.mousePosition.y, Input.mousePosition.x - cursorLastPosX, 0);
        cursorLastPosX = Input.mousePosition.x;
        cursorLastPosY = Input.mousePosition.y;
    }
}