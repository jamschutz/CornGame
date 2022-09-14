using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFader : MonoBehaviour
{
    public float fadeSpeed;
    public Image fadeImage;

    bool isFadingIn;


    float timer;
    Color imageColor;

    void Start()
    {
        timer = 0;
        isFadingIn = false;
        imageColor = Color.black;
    }


    void Update()
    {
        if(isFadingIn) {
            timer = Mathf.Clamp(timer - fadeSpeed * Time.deltaTime, 0, 1);
        }
        else {
            timer = Mathf.Clamp(timer + fadeSpeed * Time.deltaTime, 0, 1);
        }

        imageColor.a = timer;
        fadeImage.color = imageColor;
    }


    public void FadeIn()
    {
        isFadingIn = true;
    }

    public void FadeOut()
    {
        isFadingIn = false;
    }
}
