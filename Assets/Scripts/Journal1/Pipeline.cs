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
                mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());//track mouse position
                canUpdateMouse = false;//disable mouse tracking for the next 0.1 seconds
                mousePoints.Add(mousePos);//add position to the list
            }

            if (timer  >= maxTimer)//if timer is bigger than 0.1s
            {
                timer = 0;
                canUpdateMouse = true;//get a new mouse position in the list
            }
            timer += Time.deltaTime;//increase timer

            if (mousePoints.Count > 1)
            {
                for (int i = 1; i < mousePoints.Count; i++)//i starts at 1 because...
                {
                    Debug.DrawLine(mousePoints[i - 1], mousePoints[i], Color.red);//... we draw a line from one point to the one before it
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
                    magnitudeTotal += (mousePoints[i - 1] - mousePoints[i]).magnitude;//add up the length of all the lines
                }
                Debug.Log("total length: " + magnitudeTotal);//display total length
            }
            mousePoints.Clear();//clear the list when the mouse is released
            magnitudeTotal = 0;
        }
    }
}
