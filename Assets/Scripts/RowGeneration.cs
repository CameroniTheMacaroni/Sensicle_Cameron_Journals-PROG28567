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
        WRONG.SetActive(false);

        if (Int32.TryParse(tempInput, out int x))
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
            WRONG.SetActive(true);
        }

    }

    IEnumerator drawSquares()
    {
        transform.position = new Vector3 (-8, 0, 0);
        for (int i = 0; i < input; i++)
        {
            GameObject thing = Instantiate(square, transform.position, transform.rotation);

            transform.position += speed;
            yield return new WaitForSeconds(drawSpeed);

        }
    }
}
