using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornController : MonoBehaviour
{
    public Color[] colorPalette;
    public float height;
    public float growthSpeedPerMinute;



    void Update()
    {
        float cornHeight = Time.time / 60.0f * growthSpeedPerMinute;
        transform.localScale = new Vector3(cornHeight, cornHeight, cornHeight);
    }    
}
