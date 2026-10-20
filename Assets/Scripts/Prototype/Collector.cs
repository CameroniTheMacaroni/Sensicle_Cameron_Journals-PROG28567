using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public GameObject chair;
    public GameObject sofa;
    public GameObject lamp;
    public GameObject fridge;
    public GameObject drawer;
    public GameObject bed;

    public int targetNumber;
    public List<GameObject> targets;

    public float collisionDistance;
    public float score;

    void Start()
    {
        targets.Add(chair);
        targets.Add(sofa);
        targets.Add(lamp);
        targets.Add(fridge);
        targets.Add(drawer);
        targets.Add(bed);

        newTargetItem();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Random.Range(0, targets.Count));
        for (int i = 0; i < targets.Count; i++)
        {
            if(Vector3.Distance(transform.position, targets[i].transform.position) < collisionDistance)
            {
                Debug.Log("works" + i + " " + targetNumber);
                if (i == targetNumber)
                {
                    targets[i].gameObject.SetActive(false);
                    targets.Remove(targets[i].gameObject);
                    newTargetItem();
                }
            }
        }
    }

    public void newTargetItem()
    {
        targetNumber = Random.Range(0, targets.Count);
        Debug.Log("target: " + targets[targetNumber]);

    }
}
