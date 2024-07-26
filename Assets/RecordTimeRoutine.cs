using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecordTimeRoutine : MonoBehaviour
{
    private int MyPlayTime;

    public TMP_Text PlayTime;

    private int PlayTimeDay;
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

            PlayTimeDay = ts.Days;
            PlayTimeHour = (int)ts.TotalHours;
            PlayTimeMinute = ts.Minutes;
            PlayTimeSecond = ts.Seconds;

            PlayTime.text = PlayTimeDay.ToString() + " d - " + PlayTimeHour.ToString() + "hr - " + PlayTimeMinute.ToString() + "min - " + PlayTimeSecond.ToString() + "sec";

        }
    }

    public void Reset()
    {
        MyPlayTime = 0;
        PlayerPrefs.SetInt("PlayTime", MyPlayTime);
        PlayTime.text = 0 + " d - " + 0 + "hr - " + 0 + "min - " + 0 + "sec";

    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("PlayTime", MyPlayTime);
        PlayerPrefs.Save();
    }
}
