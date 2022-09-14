using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public int secondsInADay = 86400;
    public Transform sun;
    public SunlightColor[] sunlightColorTimes;


    public float timeOfDay { get; private set; }
    [SerializeField]
    private float showTimeOfDay;


    // singleton instance
    public static TimeManager instance;

    float timeToRotateOneDegree;
    float timer = 0;

    void Awake()
    {
        // ensure singleton instance 
        if(TimeManager.instance != null && TimeManager.instance != this) {
            Destroy(this.gameObject);
        }
        else {
            TimeManager.instance = this;
        }


        timeToRotateOneDegree = (float)secondsInADay / 360.0f;
    }


    void Update()
    {
        showTimeOfDay = timeOfDay;
        timer += Time.deltaTime;
        SetTimeOfDay();
        
        // not time to rotate one degree yet...
        // if(timer < timeToRotateOneDegree) return;

        Debug.Log("ROTATING SUN");

        // rotate one degree
        // sun.Rotate(Vector3.left, 1.0f);
        sun.Rotate(Vector3.left, Time.deltaTime / timeToRotateOneDegree);
        timer = 0f;
    }


    void SetTimeOfDay()
    {
        // int timeInSeconds = Mathf.FloorToInt(Time.time);        
        // timeOfDay = (float)(timeInSeconds % secondsInADay) / (float)secondsInADay;

        timeOfDay = (Time.time / (float)secondsInADay) % 1.0f;
    }
}


[System.Serializable]
public class SunlightColor
{
    public Color color;
    [Range(0,1)]
    public float time;
}