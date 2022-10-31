/***
 * Author: Akram Taghavi-Burris
 * Created: 10-30-22
 * Modified:
 * Description: Controls fire effects
 ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fire : MonoBehaviour
{
    public ParticleSystem fireParticleSystem;
    public ParticleSystem sparksParticleSystem;
    public ParticleSystem smokeParticleSystem;
    public float fireFadeDelay = 1;
    public Weather weatherSystem;
    AudioSource audioSrc;
    bool isFireOut = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        
    }//end Start()

    // Update is called once per frame
    void Update()
    {
        Debug.Log(weatherSystem.IsRaining);

        if (weatherSystem.IsRaining)
        {
            if (!isFireOut)
            {
                Invoke("ExtinguishFire", fireFadeDelay);
            }//end if (!isFireOut)
        }//end if (weatherSystem.IsRaining)
    }//end Update()



    void ExtinguishFire()
    {
        Debug.Log("ExtinguishFire Fire");

        fireParticleSystem.Stop();
        sparksParticleSystem.Stop();
        smokeParticleSystem.Play();
        audioSrc.Stop();
        isFireOut = true;
            
    }//end ExtinguishFire()





}
