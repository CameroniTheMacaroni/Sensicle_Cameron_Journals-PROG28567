using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pipeline : MonoBehaviour
{
    public Vector2 mousePos;

    public float timer;
    public float maxTimer = 0.1f;
    public bool canUpdateMouse;
    public float magnitudeTotal;

    public List<Vector2> mousePoints = new List<Vector2>();

    void Start()
    {
        
    }

    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            if (canUpdateMouse)
            {
                mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                canUpdateMouse = false;
                mousePoints.Add(mousePos);
            }

            if (timer  >= maxTimer)//if timer is bigger than 0.1s
            {
                timer = 0;
                canUpdateMouse = true;
            }
            timer += Time.deltaTime;

            if (mousePoints.Count > 1)
            {
                for (int i = 1; i < mousePoints.Count; i++)//i starts at 1
                {
                    Debug.DrawLine(mousePoints[i - 1], mousePoints[i], Color.red);
                }
            }
        }
        else
        {
            timer = 0;
            canUpdateMouse = true;

            if (mousePoints.Count > 1)
            {
                for (int i = 1; i < mousePoints.Count; i++)//i starts at 1
                {
                    magnitudeTotal += (mousePoints[i - 1] - mousePoints[i]).magnitude;
                }
                Debug.Log("total length: " + magnitudeTotal);
            }
            mousePoints.Clear();
            magnitudeTotal = 0;
        }
    }
}
