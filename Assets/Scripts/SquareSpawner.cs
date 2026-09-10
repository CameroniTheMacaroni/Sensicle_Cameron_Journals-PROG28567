using UnityEngine;
using UnityEngine.InputSystem;

public class SquareSpawner : MonoBehaviour
{
    public GameObject square;
    public bool clicked = false;
    public Vector3 squareSizeX = new Vector3(0.2f, 0, 0);
    public Vector3 squareSizeY = new Vector3(0, 0.2f, 0);
    public Vector3 mousePos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0;

        if (Mouse.current.leftButton.isPressed && clicked == false)
        {
            clicked = true;

            Instantiate(square, mousePos, transform.rotation);//spawn a square
        }
        else if(Mouse.current.leftButton.isPressed == false)
        {
            clicked = false;
        }

        Debug.DrawLine(mousePos + squareSizeX, mousePos + squareSizeY, Color.pink);//top Left
        Debug.DrawLine(mousePos - squareSizeX, mousePos + squareSizeY, Color.pink);//top Right
        Debug.DrawLine(mousePos + squareSizeX, mousePos - squareSizeY, Color.pink);//bottom Left
        Debug.DrawLine(mousePos - squareSizeX, mousePos - squareSizeY, Color.pink);//bottom Right
    }

    
}
