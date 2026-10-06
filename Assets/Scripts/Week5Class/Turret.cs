using System.Drawing;
using Unity.Mathematics;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float angularSpeed = 1;
    public float offset = 90;
    void Start()
    {
        
    }

   
    void Update()
    {
        Vector2 point = new Vector2(math.cos((transform.eulerAngles.z + offset) * Mathf.Deg2Rad), math.sin((transform.eulerAngles.z + offset) * Mathf.Deg2Rad));//calculate the x and y of the point

        Debug.DrawLine(transform.position, transform.position + (Vector3) point, UnityEngine.Color.yellow);

        transform.eulerAngles += new Vector3(0, 0, 1) * Time.deltaTime * angularSpeed;
    }
}
