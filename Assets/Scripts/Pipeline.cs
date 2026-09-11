using UnityEngine;
using UnityEngine.InputSystem;

public class Pipeline : MonoBehaviour
{
    public Vector2 mousePos;

    public float timer;
    public float maxTimer = 0.1f;
    public bool canUpdateMouse;

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
            }

            if (timer  >= maxTimer)//if timer is bigger than 0.1s
            {
                timer = 0;
                canUpdateMouse = true;
            }
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            canUpdateMouse = true;
        }
    }
}
