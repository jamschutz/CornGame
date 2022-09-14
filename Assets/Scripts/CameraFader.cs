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
    FadeAudioInOut audio;

    void Start()
    {
        timer = 0;
        isFadingIn = false;
        imageColor = Color.black;
        audio = GetComponent<FadeAudioInOut>();
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
        if(isFadingIn) return;

        audio.BeginFadeOut();
        isFadingIn = true;
    }

    public void FadeOut()
    {
        if(!isFadingIn) return;

        audio.BeginFadeIn();
        isFadingIn = false;
    }
}
