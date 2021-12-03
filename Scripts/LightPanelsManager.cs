using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensiks.SDK.Shared.SensiksDataTypes;

public class LightPanelsManager : MonoBehaviour
{
    [SerializeField]
    private ColorPicker leftPicker;
    [SerializeField]
    private ColorPicker rightPicker;

    private bool linked;

    private void Start()
    {
        SetColor(0, 0, 0);
    }

    public void ToggleLightPanelLinked()
    {
        linked = !linked;
        Debug.Log(linked);
    }

    public void ColorChanged(bool isleft)
    {
        if (isleft)
        {
            if (linked)
            {
                rightPicker.CurrentColor = leftPicker.CurrentColor;
            }
            SensiksInstance.Instance.SetLightPanelColor(LightPanelPosition.LEFT, leftPicker.CurrentColor.r, leftPicker.CurrentColor.g, leftPicker.CurrentColor.b);
        }
        else
        {
            if (linked)
            {
                leftPicker.CurrentColor = rightPicker.CurrentColor;
            }
            SensiksInstance.Instance.SetLightPanelColor(LightPanelPosition.RIGHT, rightPicker.CurrentColor.r, rightPicker.CurrentColor.g, rightPicker.CurrentColor.b);
        }
    }

    public void SetColor(LightPanelPosition pos, float r, float g, float b)
    {
        if(pos == LightPanelPosition.LEFT)
        {
            leftPicker.CurrentColor = new Color(r, g, b);
            
        }
        else
        {
            rightPicker.CurrentColor = new Color(r, g, b);
        }
    }

    public void SetColor(float r, float g, float b)
    {
        leftPicker.CurrentColor = new Color(r, g, b);
        rightPicker.CurrentColor = new Color(r, g, b);
    }
}
