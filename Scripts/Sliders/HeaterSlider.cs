using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensiks.SDK.Shared.SensiksDataTypes;
using UnityEngine.UI;

public class HeaterSlider : MonoBehaviour
{
    [SerializeField]
    private HeaterPosition position;

    public Slider slider;

    [SerializeField]
    private Text title;



    public void Start()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
        title.text = position.ToString().Replace('_', ' ').ToLower();
    }

    private void OnSliderValueChanged(float val)
    {
        //Debug.Log(position.ToString() + " : " + val);
        SensiksInstance.Instance.SetHeaterIntensity(position, val/100f);
    }

}
