using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    private Vector3 startPosition;
    private Vector3 endPosition;

    public int currentStar;
    public float linePercentage;
    public float lineDrawSpeed = 0.01f;

    public bool constellationDrawn;

    // Update is called once per frame
    void Update()
    {
        DrawConstellation();
    }

    public void DrawConstellation()
    {
        startPosition = starTransforms[currentStar].position;//decide on the start of the line
        endPosition = starTransforms[currentStar + 1].position;//decide on the end of the line

        Debug.DrawLine(startPosition, Vector3.Lerp(startPosition, endPosition, linePercentage), Color.purple);//slowly draw a line from the two points

        for (int i = 0; i < currentStar; ++i)
        {
            Debug.DrawLine(starTransforms[i].position, starTransforms[i + 1].position, Color.purple);//redraw the lines that have already been drawn
        }

        linePercentage += lineDrawSpeed;//increment how much of the line we draw

        if(linePercentage >= 1)//if the line is complete, then reset it to 0
        {
            if(currentStar == 5)//if we've gone through the list of stars... 
            {
                currentStar = 0;//... restart the process...
            }
            else//... if not... 
            {
                currentStar++;//... go to the next star.
            }
            linePercentage = 0;

        }
    }
}
