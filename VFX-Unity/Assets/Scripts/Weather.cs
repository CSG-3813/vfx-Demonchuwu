/***
 * Author: Akram Taghavi-Burris
 * Created: 10-30-22
 * Modified:
 * Description: Controls weather effects
 ***/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Weather : MonoBehaviour
{
    public GameObject rainGO;
    ParticleSystem rainPS;
    public float rainTime = 10;
    public AudioMixerSnapshot Raining;
    public AudioMixerSnapshot Sunny;
    public Volume postProcess;

    float lerpValue;
    float lerpDuration = 10;
    float transtionTime;
    float timerTime;
    bool startTimer;
    AudioSource audioSrc;
    bool isRaining = false;
    public bool IsRaining { get { return isRaining; } }

    // Start is called before the first frame update
    void Start()
    {
        rainPS = rainGO.GetComponent<ParticleSystem>();
        audioSrc= rainGO.GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            if (timerTime > 0)
            {
                timerTime -= Time.deltaTime;
                TintSky();

            }else{
                EndRain();
            } //end if (timeRemaining > 0)
        }//end if (startTimer)
    }//end Update()


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter Rain");

        if(other.tag == "Player")
        {
            //if the timer has not yet started
            if (!startTimer)
            {
                timerTime = rainTime;
                startTimer = true;
                isRaining = true;
                rainPS.Play();
                audioSrc.Play();
                Raining.TransitionTo(2.0f);
            }//end if (!startTimer)

        }//end if(other.tag == "Player")
    }//end OnTriggerEnter()

    void TintSky()
    {
        
        if (transtionTime < lerpDuration)
        {
            lerpValue = Mathf.Lerp(0, 1, transtionTime / lerpDuration);
            Debug.Log(lerpValue);
            transtionTime += Time.deltaTime;
            postProcess.weight = lerpValue;

        }

    }//end TintSky()

    void EndRain()
    {
        startTimer = false;
        isRaining = false;
        timerTime = rainTime;
        rainPS.Stop();
        audioSrc.Stop();
        Sunny.TransitionTo(2.0f);

    }//end EndRain()




}
