using UnityEngine;
using UnityEngine.InputSystem;

public class SquareSpawner : MonoBehaviour
{
    
    public bool clicked = false;
    public Vector2 squareSizeX = new Vector2(0.2f, 0);
    public Vector2 squareSizeY = new Vector2(0, 0.2f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Mouse.current.leftButton.isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Debug.Log(mousePos);
            clicked = true;

            drawSquare(mousePos);
        }
        else
        {
            clicked = false;
        }
    }

    public void drawSquare(Vector2 mousepos)
    {
        Debug.DrawLine(mousepos + squareSizeX, mousepos + squareSizeY, Color.red);//top Left
        Debug.DrawLine(mousepos - squareSizeX, mousepos + squareSizeY, Color.red);//top Right
        Debug.DrawLine(mousepos + squareSizeX, mousepos - squareSizeY, Color.red);//bottom Left
        Debug.DrawLine(mousepos - squareSizeX, mousepos - squareSizeY, Color.red);//bottom Right
    }
    
}
