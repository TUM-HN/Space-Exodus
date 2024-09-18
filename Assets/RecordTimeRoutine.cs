using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
 * RecordTimeRoutine is designed to track gameplay duration. 
 * The Start() method retrieves the previously recorded playtime and initiates a new time calculation by calling RecordTime(). 
 * In addition to starting the timer, RecordTime() is also responsible for displaying the playtime in the pause menu. 
 * The Reset() method allows for resetting the MyPlayTime parameter. 
 * The OnApplicationQuit() method ensures that the gameplay duration is recorded in player preferences
 * 
 * The following YouTube video and webpage served as references for the creation of this script
 * YT:https://www.youtube.com/watch?v=IQkabxKDY3M
 * Webpage: https://discussions.unity.com/t/how-to-record-the-real-playing-time/127990
 */

public class RecordTimeRoutine : MonoBehaviour
{
    private int MyPlayTime;

    public TMP_Text PlayTime;

    private int PlayTimeHour;
    private int PlayTimeMinute;
    private int PlayTimeSecond;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayTime")) { MyPlayTime = PlayerPrefs.GetInt("PlayTime"); }
        else {
            MyPlayTime = 0;
            PlayerPrefs.SetInt("PlayTime", MyPlayTime);
        }
        StartCoroutine(RecordTime());
    }

    public IEnumerator RecordTime()
    {
        TimeSpan ts;
        while (true)
        {
            yield return new WaitForSeconds(1);
            MyPlayTime += 1;

            ts = TimeSpan.FromSeconds((double)MyPlayTime);

            PlayTimeHour = (int)ts.TotalHours;
            PlayTimeMinute = ts.Minutes;
            PlayTimeSecond = ts.Seconds;

            string hour = "";

            if (PlayTimeHour != 0) {
                hour = PlayTimeHour.ToString() + "hr - ";
            }
            //string hour = PlayTimeHour == 0 ? (PlayTimeHour.ToString() + "hr - ") : "";

            PlayTime.text =  hour + PlayTimeMinute.ToString() + "min - " + PlayTimeSecond.ToString() + "sec";
           
        }
    }

    public void Reset()
    {
        MyPlayTime = 0;
        PlayerPrefs.SetInt("PlayTime", MyPlayTime);
        PlayTime.text = 0 + "min - " + 0 + "sec";

    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("PlayTime", MyPlayTime);
        PlayerPrefs.Save();
    }
}
