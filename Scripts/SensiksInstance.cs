using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensiks.SDK.Shared.SensiksDataTypes;
using Sensiks.SDK.UnityLibrary;
using System;

public class SensiksInstance : MonoBehaviour
{
    public static SensiksInstance Instance;

    private HeaterActuator heaterLeft;
    private HeaterActuator heaterRight;
    private HeaterActuator heaterRearLeft;
    private HeaterActuator heaterRearRight;
    private HeaterActuator heaterFront;

    private FanActuator fanFrontLeft;
    private FanActuator fanFrontRight;
    private FanActuator fanRearLeft;
    private FanActuator fanRearRight;

    private ScentActuator scentSmoke;
    private ScentActuator scentMetal;
    private ScentActuator scentMistySwamp;
    private ScentActuator scentSea;
    private ScentActuator scentGrass;
    private ScentActuator scentReptile;

    private LightPanelActuator lightpanelLeft;
    private LightPanelActuator lightpanelRight;

    private CeilingActuator ceilingActuator;

    private List<Actuator> stashedValues = new List<Actuator>();

    private ControlPodviewActuators _podviewActuators;
    private ControlPodviewActuators podviewActuators
    {
        get
        {
            if(_podviewActuators == null)
            {
                _podviewActuators = FindObjectOfType<ControlPodviewActuators>();
            }
            return _podviewActuators;
        }
    }


    private ScenesManager _scenesManager;
    private ScenesManager scenesManager
    {
        get
        {
            if(_scenesManager == null)
            {
                _scenesManager = FindObjectOfType<ScenesManager>();
            }
            return _scenesManager;
        }
    }


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        heaterLeft = new HeaterActuator(HeaterPosition.LEFT);
        heaterRight = new HeaterActuator(HeaterPosition.RIGHT);
        heaterRearLeft = new HeaterActuator(HeaterPosition.SEAT_LEFT);
        heaterRearRight = new HeaterActuator(HeaterPosition.SEAT_RIGHT);
        heaterFront = new HeaterActuator(HeaterPosition.FRONT);

        fanFrontLeft = new FanActuator(FanPosition.FRONT_LEFT);
        fanFrontRight = new FanActuator(FanPosition.FRONT_RIGHT);
        fanRearLeft = new FanActuator(FanPosition.REAR_LEFT);
        fanRearRight = new FanActuator(FanPosition.REAR_RIGHT);

        scentSmoke = new ScentActuator(Scent.SMOKE);
        scentMetal = new ScentActuator(Scent.METAL);
        scentMistySwamp = new ScentActuator(Scent.MISTY_SWAMP);
        scentSea = new ScentActuator(Scent.SEA);
        scentGrass = new ScentActuator(Scent.GRASS);
        scentReptile = new ScentActuator(Scent.REPTILE);

        lightpanelLeft = new LightPanelActuator(LightPanelPosition.LEFT);
        lightpanelRight = new LightPanelActuator(LightPanelPosition.RIGHT);

        ceilingActuator = new CeilingActuator(CeilingAnimation.OFF);
    }

    public void StashCurrentValues()
    {
        List<Actuator> stashedActuators = new List<Actuator>();
        stashedActuators.Add(new HeaterActuator(heaterLeft));
        stashedActuators.Add(new HeaterActuator(heaterRight));
        stashedActuators.Add(new HeaterActuator(heaterRearLeft));
        stashedActuators.Add(new HeaterActuator(heaterRearRight));
        stashedActuators.Add(new HeaterActuator(heaterFront));

        stashedActuators.Add(new FanActuator(fanFrontLeft));
        stashedActuators.Add(new FanActuator(fanFrontRight));
        stashedActuators.Add(new FanActuator(fanRearLeft));
        stashedActuators.Add(new FanActuator(fanRearRight));

        stashedActuators.Add(new ScentActuator(scentSmoke));
        stashedActuators.Add(new ScentActuator(scentMetal));
        stashedActuators.Add(new ScentActuator(scentMistySwamp));
        stashedActuators.Add(new ScentActuator(scentSea));
        stashedActuators.Add(new ScentActuator(scentGrass));
        stashedActuators.Add(new ScentActuator(scentReptile));

        stashedActuators.Add(new LightPanelActuator(lightpanelLeft));
        stashedActuators.Add(new LightPanelActuator(lightpanelRight));

        stashedActuators.Add(new CeilingActuator(ceilingActuator));

        stashedValues = stashedActuators;
    }

    public void PopStashedValues()
    {
        foreach(Actuator a in stashedValues)
        {
            switch (a.actuatorType)
            {
                case ActuatorType.HEATER:
                    HeaterActuator h = (HeaterActuator)a;
                    SetHeaterIntensity(h.position, h.value);
                    switch (h.position)
                    {
                        case HeaterPosition.LEFT:
                            scenesManager.heaterLeft.slider.value = h.value * 100;
                            break;
                        case HeaterPosition.RIGHT:
                            scenesManager.heaterRight.slider.value = h.value * 100;
                            break;
                        case HeaterPosition.SEAT_LEFT:
                            scenesManager.heaterRearLeft.slider.value = h.value * 100;
                            break;
                        case HeaterPosition.SEAT_RIGHT:
                            scenesManager.heaterRearRight.slider.value = h.value * 100;
                            break;
                        case HeaterPosition.FRONT:
                            scenesManager.heaterFront.slider.value = h.value * 100;
                            break;
                    }
                    break;
                case ActuatorType.FAN:
                    FanActuator f = (FanActuator)a;
                    SetFanIntenisty(f.position, f.value);
                    switch (f.position)
                    {
                        case FanPosition.FRONT_LEFT:
                            scenesManager.fanFrontLeft.slider.value = f.value * 100;
                            break;
                        case FanPosition.FRONT_RIGHT:
                            scenesManager.fanFrontRight.slider.value = f.value * 100;
                            break;
                        case FanPosition.REAR_LEFT:
                            scenesManager.fanRearLeft.slider.value = f.value * 100;
                            break;
                        case FanPosition.REAR_RIGHT:
                            scenesManager.fanRearRight.slider.value = f.value * 100;
                            break;
                    }
                    break;
                case ActuatorType.SCENT:
                    ScentActuator s = (ScentActuator)a;
                    SetScentIntensity(s.position, s.value);
                    break;
                case ActuatorType.LIGHT_PANEL:
                    LightPanelActuator l = (LightPanelActuator)a;
                    SetLightPanelColor(l.position, l.rValue, l.gValue, l.bValue);
                    scenesManager.lightPanels.SetColor(l.position, l.rValue, l.gValue, l.bValue);
                    break;
                case ActuatorType.CEILING:
                    CeilingActuator c = (CeilingActuator)a;
                    SetCeilingAnimation(c.animation);
                    scenesManager.ceilingButtons.SetCeilingAnimation((int)c.animation);
                    break;
            }
        }
    }

    public void SetHeaterIntensity(HeaterPosition pos, float intenstiy)
    {
        switch (pos)
        {
            case HeaterPosition.LEFT:
                heaterLeft.value = intenstiy;
                break;
            case HeaterPosition.RIGHT:
                heaterRight.value = intenstiy;
                break;
            case HeaterPosition.SEAT_LEFT:
                heaterRearLeft.value = intenstiy;
                break;
            case HeaterPosition.SEAT_RIGHT:
                heaterRearRight.value = intenstiy;
                break;
            case HeaterPosition.FRONT:
                heaterFront.value = intenstiy;
                break;
        }
        podviewActuators.SetHeaterItensity(pos, intenstiy);
        SensiksManager.SetHeaterIntensity(pos, intenstiy);
    }

    public void SetFanIntenisty(FanPosition pos, float intensity)
    {
        switch (pos)
        {
            case FanPosition.FRONT_LEFT:
                fanFrontLeft.value = intensity;
                break;
            case FanPosition.FRONT_RIGHT:
                fanFrontRight.value = intensity;
                break;
            case FanPosition.REAR_LEFT:
                fanRearLeft.value = intensity;
                break;
            case FanPosition.REAR_RIGHT:
                fanRearRight.value = intensity;
                break;
        }
        podviewActuators.SetFanIntensity(pos, intensity);
        SensiksManager.SetFanIntensity(pos, intensity);
    }

    public void SetScentIntensity(Scent scent, float intensity)
    {
        switch (scent)
        {
            case Scent.SMOKE:
                scentSmoke.value = intensity;
                break;
            case Scent.METAL:
                scentMetal.value = intensity;
                break;
            case Scent.MISTY_SWAMP:
                scentMistySwamp.value = intensity;
                break;
            case Scent.SEA:
                scentSea.value = intensity;
                break;
            case Scent.GRASS:
                scentGrass.value = intensity;
                break;
            case Scent.REPTILE:
                scentReptile.value = intensity;
                break;

        }
        SensiksManager.SetActiveScent(scent, intensity);
    }

    public void SetCeilingAnimation(CeilingAnimation anim)
    {
        ceilingActuator.animation = anim;
        SensiksManager.SetActiveCeilingAnimation(anim);
        podviewActuators.SetCeilingAnimation(anim);
    }

    public void SetLightPanelColor(LightPanelPosition pos, float rValue, float gValue, float bValue)
    {
        switch (pos)
        {
            case LightPanelPosition.LEFT:
                lightpanelLeft.rValue = rValue;
                lightpanelLeft.gValue = gValue;
                lightpanelLeft.bValue = bValue;
                break;
            case LightPanelPosition.RIGHT:
                lightpanelRight.rValue = rValue;
                lightpanelRight.gValue = gValue;
                lightpanelRight.bValue = bValue;
                break;
        }
        podviewActuators.SetLightPanelColor(pos, rValue, gValue, bValue);
        SensiksManager.SetLightColor(pos, rValue, gValue, bValue, 0);
        //Debug.Log("Lightpanel: " + pos.ToString() + " R:" + rValue + " G:" + gValue + " B:" + bValue);
    }
}
