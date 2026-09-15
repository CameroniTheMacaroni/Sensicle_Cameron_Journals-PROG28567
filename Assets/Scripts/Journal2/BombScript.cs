using System.Collections;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public Vector3 shrink = new Vector3(0.2f, 0.2f, 0);
    void Start()
    {
        StartCoroutine(explodeCounddown());
    }


    void Update()
    {

    }

    IEnumerator explodeCounddown()
    {
        for (int i = 0; i < 3; i++)
        {
            transform.localScale -= shrink;
            yield return new WaitForSeconds(1);
        }

        transform.localScale += new Vector3(5, 5, 0);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
