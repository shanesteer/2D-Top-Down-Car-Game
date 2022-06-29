using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTime : MonoBehaviour
{
    public static int minuteCount;
    public static int secondCount;
    public static float millisecondCount;
    public static string milliDisplay;
    public GameObject min;
    public GameObject sec;
    public GameObject milli;

    public Text lapTimeText;


    // Update is called once per frame
    void Update()
    {
        millisecondCount += Time.deltaTime * 10;
        milliDisplay = millisecondCount.ToString("F0");
        milli.GetComponent<Text>().text = "" + milliDisplay;

        if(millisecondCount >= 10)
        {
            millisecondCount = 0;
            secondCount += 1;
        }

        if(secondCount <= 9)
        {
            sec.GetComponent<Text>().text = "0" + secondCount + ".";
        }

        else
        {
            sec.GetComponent<Text>().text = "" + secondCount + ".";
        }

        if(secondCount >= 60)
        {
            secondCount = 0;
            minuteCount += 1;
        }

        if(minuteCount <= 9)
        {
            min.GetComponent<Text>().text = "0" + minuteCount + ":";
        }

        else
        {
            min.GetComponent<Text>().text = "" + minuteCount + ":";
        }

        lapTimeText.text = "Lap Time:  " + minuteCount + " : " + secondCount;

    }
}
