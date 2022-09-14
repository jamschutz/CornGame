using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAudioInOut : MonoBehaviour
{
    public float fadeInTime;
    public float fadeOutTime;
    public AnimationCurve fadeOutCurve;
    public AnimationCurve fadeInCurve;


    AudioSource audio;
    float targetVolume;


    void Start()
    {
        audio = GetComponent<AudioSource>();
        targetVolume = audio.volume;
        Debug.Log($"set {gameObject.name} target volume to {targetVolume}");

        audio.time = 15;
    }


    public void BeginFadeIn()
    {
        Debug.Log("beginning audio!");
        StopCoroutine("FadeOut");

        // reset audio clip
        // if(!audio.isPlaying) {
        //     audio.time = 15;
        // }
        StartCoroutine("FadeIn");
    }

    public void BeginFadeOut()
    {
        Debug.Log("stopping audio!");
        StopCoroutine("FadeIn");
        Debug.Log("still stopping audio!");
        StartCoroutine("FadeOut");
    }


    IEnumerator FadeIn()
    {
        audio.volume = 0;
        if(audio.isPlaying == false) {
            audio.Play();
        }

        float timer = 0;
        while(timer < fadeInTime) {
            audio.volume = fadeInCurve.Evaluate(Mathf.Lerp(0, targetVolume, timer / fadeInTime));
            Debug.Log($"fading in!!! timer: {timer},   volume: {audio.volume}");

            timer += Time.deltaTime;
            yield return null;
        }

        // for good measure, make sure the volume got all the way
        audio.volume = targetVolume;
    }


    IEnumerator FadeOut()
    {
        Debug.Log("HERE");
        float timer = 0;
        while(timer < fadeOutTime) {
            audio.volume = fadeOutCurve.Evaluate(Mathf.Lerp(targetVolume, 0, timer / fadeOutTime));
            Debug.Log($"fading out!!! timer: {timer},   volume: {audio.volume}");

            timer += Time.deltaTime;
            yield return null;
        }

        audio.Pause();
    }
}
