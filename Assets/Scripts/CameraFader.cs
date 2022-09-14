using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFader : MonoBehaviour
{
    public float fadeSpeed;
    public float fadeOutSpeed;
    public Image fadeImage;

    bool isFadingIn;


    [SerializeField]
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


    // void Update()
    // {
    //     if(isFadingIn) {
    //         timer -= Time.deltaTime;
    //         timer = Mathf.Clamp(timer / fadeSpeed, 0, 1);
    //     }
    //     else {
    //         timer += Time.deltaTime;
    //         timer = Mathf.Clamp(timer / fadeSpeed, 0, 1);
    //     }

    //     imageColor.a = timer;
    //     fadeImage.color = imageColor;
    // }


    public void FadeIn()
    {
        if(isFadingIn) return;

        audio.BeginFadeOut();
        StopCoroutine("IFadeIn");
        StartCoroutine("IFadeOut");
        isFadingIn = true;
    }

    public void FadeOut()
    {
        if(!isFadingIn) return;

        audio.BeginFadeIn();
        StopCoroutine("IFadeOut");
        StartCoroutine("IFadeIn");
        isFadingIn = false;
    }


    IEnumerator IFadeIn()
    {
        float timer = fadeImage.color.a * fadeSpeed;
        while(timer < fadeSpeed) {
            imageColor.a = Mathf.Lerp(0, 1, timer / fadeSpeed);
            fadeImage.color = imageColor;

            timer += Time.deltaTime;
            yield return null;
        }

        // for good measure, make sure the volume got all the way
        imageColor.a = 1;
        timer = fadeSpeed;
        fadeImage.color = imageColor;
    }


    IEnumerator IFadeOut()
    {
        float timer = 1.0f - (fadeImage.color.a * fadeOutSpeed);
        while(timer < fadeOutSpeed) {
            imageColor.a = Mathf.Lerp(1, 0, timer / fadeOutSpeed);
            fadeImage.color = imageColor;

            timer += Time.deltaTime;
            yield return null;
        }

        // for good measure, make sure the volume got all the way
        imageColor.a = 0;
        timer = 0;
        fadeImage.color = imageColor;
    }
}
