using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stopwatch : MonoBehaviour
{
    public float timeValue = 1;
    public Text time;
    void Update()
    {
        if (timeValue > 0){
            timeValue += Time.deltaTime;
        }
        else{
            timeValue = 0;
        }

        if (timeValue > 80){
            time.color = Color.red;
        }
        ShowTime(timeValue);
    }

    private void ShowTime(float timeDisplay){
        if (timeDisplay < 0){
            timeDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeDisplay / 60);
        float seconds = Mathf.FloorToInt(timeDisplay % 60);

        time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
