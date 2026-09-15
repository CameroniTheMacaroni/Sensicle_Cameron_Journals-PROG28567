using System;
using System.Collections;
using UnityEngine;

public class RowGeneration : MonoBehaviour
{
    public int input;
    public float drawSpeed = 0.2f;
    public bool validNumber;

    public GameObject square;
    public GameObject WRONG;
    public Vector3 speed = new Vector3(0.4f, 0, 0);

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void readInput(string tempInput)
    {
        WRONG.SetActive(false);//turn off invalid screen

        if (Int32.TryParse(tempInput, out int x))//try to convert the input from a string to an int
        {
            input = x;
            validNumber = true;
        }
        else
        {
            validNumber = false;

        }
    }

    public void drawSquaresCoroutine()
    {
        if (validNumber)
        {
            StartCoroutine(drawSquares());
        }
        else
        {
            WRONG.SetActive(true);//turn on invalid number screen
        }

    }

    IEnumerator drawSquares()
    {
        transform.position = new Vector3 (-8, 0, 0);//move all the way to the left
        for (int i = 0; i < input; i++)
        {
            GameObject thing = Instantiate(square, transform.position, transform.rotation);//spawn a square

            transform.position += speed;//move to the right a bit
            yield return new WaitForSeconds(drawSpeed);//wait

        }
    }
}
