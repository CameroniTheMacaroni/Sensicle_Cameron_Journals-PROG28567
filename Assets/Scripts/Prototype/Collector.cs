using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collector : MonoBehaviour
{
    //win/lose condition popups
    public GameObject youWin;
    public GameObject youLose;

    //UI text
    public TextMeshProUGUI targetText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    //collectables
    public GameObject chair;
    public GameObject sofa;
    public GameObject lamp;
    public GameObject fridge;
    public GameObject drawer;
    public GameObject bed;

    public GameObject checkout;

    //target list
    public int targetNumber;
    public List<GameObject> targets;

    //adjustable floats
    public float collisionDistance;
    public float score = 7;
    public float timer = 150;

    //booleans
    public bool foundEverything;
    public bool gameWon;

    void Start()
    {
        targets.Add(chair);//add all the collectables to the list
        targets.Add(sofa);
        targets.Add(lamp);
        targets.Add(fridge);
        targets.Add(drawer);
        targets.Add(bed);

        newTargetItem();//generate a new collectable that the player has to go find
    }

    void Update()
    {
        timer -= Time.deltaTime;//count down the timer
        timerText.text = "time remaining: " + Mathf.Round(timer);//display timer
        
        if (!foundEverything)//if the player hasn't found everything...
        {
            for (int i = 0; i < targets.Count; i++)//... go though the list of all the collectables... 
            {
                if (Vector3.Distance(transform.position, targets[i].transform.position) < collisionDistance)//... and detect if they're close enough to the player, ... 
                {
                    if (i == targetNumber)//... then make sure that the player is close to the right one... 
                    {
                        //... if true... 
                        targets[i].gameObject.SetActive(false);//... disable the collected item, ... 
                        targets.Remove(targets[i].gameObject);//... remove it from the list...
                        newTargetItem();//... and generate a new number.
                    }
                }
            }
        }
        else// if the player has found all the collectables... 
        {
            if (Vector3.Distance(transform.position, checkout.transform.position) < collisionDistance)//... test for if they're close to the checkout...
            {
                youWin.SetActive(true);//... if they are, then they win.
                gameWon = true;
            }
        }
        if (timer <= 0)// if the timer runs out... 
        {
            if (!gameWon)
            {
                youLose.SetActive(true);//... the player loses.
            }
        }
    }

    public void newTargetItem()
    {
        score--;//update the remaining collectables to find 
        scoreText.text = "Remaining: " + score;//update text

        if (targets.Count > 0)//if theres more to find... 
        {
            targetNumber = Random.Range(0, targets.Count);//... generate a new number for something to find

            targetText.text = "Find: " + targets[targetNumber].name;//update the target text
        }
        else
        {
            foundEverything = true;
            targetText.text = "Find: Checkout";//update the target text for when the player has found everything
        }


    }
}
