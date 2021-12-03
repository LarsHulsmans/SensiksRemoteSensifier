using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem main;
    [SerializeField]
    private ParticleSystem second;


    private void Start()
    {
        setIntensity(0);
    }

    public void setIntensity(float intensity)
    {
        if(intensity == 0)
        {
            //turn off
            main.Stop();
            second.Stop();
        }
        else
        {
            if (!main.isPlaying)
            {
                main.Play();
                second.Play();
            }
            var emission = second.emission;
            emission.rateOverTimeMultiplier = 1 + (intensity*3);
            var mainEmission = main.emission;
            mainEmission.rateOverTimeMultiplier = 1 + (intensity * 3);
        }
    }

}
