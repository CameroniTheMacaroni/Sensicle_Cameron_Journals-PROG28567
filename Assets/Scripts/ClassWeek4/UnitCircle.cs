using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnitCircle : MonoBehaviour
{
    public List<float> angles;
    public int numberOfAngles = 10;
    public int currentAngle = 0;

    void Start()
    {
        for (int i = 0; i < numberOfAngles; i++)
        {
            angles.Add(UnityEngine.Random.Range(1, 360));//fill the list with 10 random angles
        }
    }

    void Update()
    {
        Vector2 point = new Vector2(math.cos(angles[currentAngle]), math.sin(angles[currentAngle]));//calculate the x and y of the point
        Debug.DrawLine(Vector2.zero, point, Color.yellow);//draw a line from the origin to the point

        if (Keyboard.current.spaceKey.wasPressedThisFrame)//if space is pressed... 
        {
            if (currentAngle < numberOfAngles - 1)//... if there are more angles in the list... 
            {
                currentAngle++;//... go to the next angle... 
            }
            else//... if not... 
            {
                currentAngle = 0;//... restart to the first angle
            }
        }
    }
}
