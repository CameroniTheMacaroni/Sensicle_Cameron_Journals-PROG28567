using UnityEngine;
using UnityEngine.InputSystem;

public class PrototypePlayer : MonoBehaviour
{
    public float speed = 5;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            transform.position += speed * Time.deltaTime * Vector3.up;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            transform.position += speed * Time.deltaTime * Vector3.right;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            transform.position += speed * Time.deltaTime * Vector3.down;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            transform.position += speed * Time.deltaTime * Vector3.left;
        }
    }
}
