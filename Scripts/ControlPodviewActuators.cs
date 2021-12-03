using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensiks.SDK.Shared.SensiksDataTypes;
using System;

public class ControlPodviewActuators : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer heaterLeft;
    [SerializeField]
    private MeshRenderer heaterRight;
    [SerializeField]
    private MeshRenderer heaterRearLeft;
    [SerializeField]
    private MeshRenderer heaterRearRight;
    [SerializeField]
    private MeshRenderer heaterFront;

    [SerializeField]
    private ParticleSystemController frontLeft;
    [SerializeField]
    private ParticleSystemController frontRight;
    [SerializeField]
    private ParticleSystemController rearRight;
    [SerializeField]
    private ParticleSystemController rearLeft;

    [SerializeField]
    private MeshRenderer lightPanelLeft;
    [SerializeField]
    private MeshRenderer lightPanelRight;

    [SerializeField]
    private MeshRenderer ceilingAnim;

    private void Start()
    {
        foreach(HeaterPosition pos in (HeaterPosition[])Enum.GetValues(typeof(HeaterPosition)))
        {
            SetHeaterItensity(pos, 0);
        }
    }

    public void SetHeaterItensity(HeaterPosition pos, float intensity)
    {
        Color col = new Color(intensity, intensity, intensity);
        switch (pos)
        {
            case HeaterPosition.LEFT:
                heaterLeft.material.SetColor("_EmissionColor", col);
                break;
            case HeaterPosition.RIGHT:
                heaterRight.material.SetColor("_EmissionColor", col);
                break;
            case HeaterPosition.SEAT_LEFT:
                heaterRearLeft.material.SetColor("_EmissionColor", col);
                break;
            case HeaterPosition.SEAT_RIGHT:
                heaterRearRight.material.SetColor("_EmissionColor", col);
                break;
            case HeaterPosition.FRONT:
                heaterFront.material.SetColor("_EmissionColor", col);
                break;
        }
    }

    public void SetFanIntensity(FanPosition pos, float intensity)
    {
        switch (pos)
        {
            case FanPosition.FRONT_LEFT:
                frontLeft.setIntensity(intensity);
                break;
            case FanPosition.FRONT_RIGHT:
                frontRight.setIntensity(intensity);
                break;
            case FanPosition.REAR_LEFT:
                rearLeft.setIntensity(intensity);
                break;
            case FanPosition.REAR_RIGHT:
                rearRight.setIntensity(intensity);
                break;
        }
    }

    public void SetLightPanelColor(LightPanelPosition pos, float r, float g, float b)
    {
        Debug.Log("Set lightpanel color to:" + r + ", " + g + ", " + b);
        Color col = new Color(r, g, b);
        switch (pos)
        {
            case LightPanelPosition.LEFT:
                lightPanelLeft.material.EnableKeyword("_EMISSION");
                lightPanelLeft.material.SetColor("_EmissionColor", col);
                break;
            case LightPanelPosition.RIGHT:
                lightPanelRight.material.EnableKeyword("_EMISSION");
                lightPanelRight.material.SetColor("_EmissionColor", col);
                break;
        }
    }

    public void SetCeilingAnimation(CeilingAnimation anim)
    {
        ceilingAnim.material.EnableKeyword("_EMISSION");
        switch (anim)
        {
            case CeilingAnimation.FOREST:
                Color forestColor = new Color(0f,1f,0f);
                ceilingAnim.material.SetColor("_EmissionColor", forestColor);
                break;
            case CeilingAnimation.SKY:
                Color skyColor = new Color(0f,0.69f,1f);
                ceilingAnim.material.SetColor("_EmissionColor", skyColor);
                break;
            case CeilingAnimation.STARS:
                Color starsColor = new Color(0.7f,0.7f,0.7f);
                ceilingAnim.material.SetColor("_EmissionColor", starsColor);
                break;
            case CeilingAnimation.SUN:
                Color sunColor = new Color(1f,1f,0f);
                ceilingAnim.material.SetColor("_EmissionColor", sunColor);
                break;
            case CeilingAnimation.OFF:
                Color offColor = new Color(0,0,0);
                ceilingAnim.material.SetColor("_EmissionColor", offColor);
                break;
        }
    }
}
