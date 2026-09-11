using System;
using System.Collections;
using UnityEngine;

public class RowGeneration : MonoBehaviour
{
    public int input;
    public float drawSpeed = 0.2f;

    public GameObject square;
    public Vector3 speed = new Vector3(0.4f, 0, 0);

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void readInput(string tempInput)
    {
        //Debug.Log("input: " + tempInput);
        //input = Int32.Parse(tempInput);
        if (Int32.TryParse(tempInput, out int x))
        {
            Debug.Log(x);
            input = x;
        }
        else
        {
            Debug.Log("no");
        }
        //Debug.Log(Int32.TryParse(tempInput, out int x));
    }

    public void drawSquaresCoroutine()
    {
        StartCoroutine(drawSquares());
    }

    IEnumerator drawSquares()
    {
        Debug.Log(input);
        transform.position = new Vector3 (-8, 0, 0);
        for (int i = 0; i < input; i++)
        {
            Debug.Log("for loop");
            Instantiate(square, transform.position, transform.rotation);
            transform.position += speed;
            yield return new WaitForSeconds(drawSpeed);

        }
    }
}
