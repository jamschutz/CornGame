using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornController : MonoBehaviour
{
    public Color[] colorPalette;
    public float height;


    void Update()
    {
        transform.localScale = new Vector3(height, height, height);
    }    
}
