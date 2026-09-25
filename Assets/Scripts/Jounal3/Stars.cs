using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    private Vector3 currentPosition;
    private Vector3 startPosition;
    private Vector3 endPosition;

    public int currentStar;
    public float linePercentage;
    public float lineDrawSpeed = 0.01f;

    public bool constellationDrawn;

    // Update is called once per frame
    void Update()
    {
        if (!constellationDrawn)
        {

            //StartCoroutine(Drawconstellation());
            DrawConstellation();
            //constellationDrawn = true;
        }
    }

    public void DrawConstellation()
    {
        startPosition = starTransforms[currentStar].position;
        endPosition = starTransforms[currentStar + 1].position;

        Debug.DrawLine(startPosition, Vector3.Lerp(startPosition, endPosition, linePercentage), Color.purple);
        for (int i = 0; i < currentStar; ++i)
        {
            Debug.DrawLine(starTransforms[i].position, starTransforms[i + 1].position, Color.purple);
        }
        //Debug.Log(Vector3.Lerp(startPosition, endPosition, 0));
        linePercentage += lineDrawSpeed;

        if(linePercentage >= 1)
        {
            if(currentStar == 5)
            {
                currentStar = 0;
            }
            else
            {
                currentStar++;
            }
            linePercentage = 0;

        }
    }
}
