using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceOffSliders : MonoBehaviour
{
    [SerializeField]
    private Slider[] sliders;


    public void ForceOff()
    {
        foreach(Slider s in sliders)
        {
            s.value = 0;
        }
    }

}
