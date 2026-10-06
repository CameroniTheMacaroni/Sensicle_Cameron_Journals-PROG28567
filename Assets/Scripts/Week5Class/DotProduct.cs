using Unity.Mathematics;
using UnityEngine;

public class DotProduct : MonoBehaviour
{
    public float redAngle = 90;
    public float blueAngle = 130;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 redPoint = new Vector2(math.cos(redAngle * Mathf.Deg2Rad), math.sin(redAngle * Mathf.Deg2Rad));//calculate the x and y of the point
        Vector2 bluePoint = new Vector2(math.cos(blueAngle * Mathf.Deg2Rad), math.sin(blueAngle * Mathf.Deg2Rad));//calculate the x and y of the point

        Debug.DrawLine(Vector2.zero, redPoint, Color.red);
        Debug.DrawLine(Vector2.zero, bluePoint, Color.blue);

    }
}
