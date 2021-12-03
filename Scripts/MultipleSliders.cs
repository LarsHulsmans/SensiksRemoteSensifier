using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultipleSliders : MonoBehaviour
{
    [SerializeField]
    private Slider[] sliders;

    [SerializeField]
    private Slider allSlider;

    public void OnSliderValueChange()
    {
        foreach(Slider s in sliders)
        {
            s.value = allSlider.value;
        }
    }
}
