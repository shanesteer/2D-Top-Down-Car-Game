using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapComplete : MonoBehaviour
{
    public GameObject trackComplete;
    public GameObject halfWay;
    public GameObject minuteBest;
    public GameObject secondBest;
    public GameObject millisecondBest;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(LapTime.secondCount <= 9)
        {
            secondBest.GetComponent<Text>().text = "0" + LapTime.secondCount + ".";
        }

        else
        {
            secondBest.GetComponent<Text>().text = "" + LapTime.secondCount + ".";
        }

        if(LapTime.minuteCount <= 9)
        {
            minuteBest.GetComponent<Text>().text = "0" + LapTime.minuteCount + ".";
        }

        else
        {
            minuteBest.GetComponent<Text>().text = "" + LapTime.minuteCount + "";
        }

        millisecondBest.GetComponent<Text>().text = "" + LapTime.millisecondCount;

        LapTime.minuteCount = 0;
        LapTime.secondCount = 0;
        LapTime.millisecondCount = 0;

        halfWay.SetActive(true);
        trackComplete.SetActive(false);

        
    }

   
    
}
