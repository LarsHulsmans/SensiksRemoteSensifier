using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensiks.SDK.Shared.SensiksDataTypes;

public class ScenesManager : MonoBehaviour
{
    [SerializeField]
    public HeaterSlider heaterLeft;
    [SerializeField]
    public HeaterSlider heaterRight;
    [SerializeField]
    public HeaterSlider heaterRearLeft;
    [SerializeField]
    public HeaterSlider heaterRearRight;
    [SerializeField]
    public HeaterSlider heaterFront;

    [SerializeField]
    public FanSlider fanFrontLeft;
    [SerializeField]
    public FanSlider fanFrontRight;
    [SerializeField]
    public FanSlider fanRearLeft;
    [SerializeField]
    public FanSlider fanRearRight;

    [SerializeField]
    public ScentSlider scentSea;
    [SerializeField]
    public ScentSlider scentReptile;
    [SerializeField]
    public ScentSlider scentSmoke;
    [SerializeField]
    public ScentSlider scentGrass;
    [SerializeField]
    public ScentSlider scentMistySwamp;
    [SerializeField]
    public ScentSlider scentMetal;

    [SerializeField]
    public CeilingButtonsManager ceilingButtons;
    [SerializeField]
    public LightPanelsManager lightPanels;

    [SerializeField]
    public ButtonActivation menuScene;
    [SerializeField]
    public ButtonActivation gameScene;


    private ButtonActivation currentScene = null;


    public void SetMenuScene()
    {
        if(currentScene != null && currentScene != menuScene)
        {
            currentScene.SetActiveNoInvoke(false);
        }
        currentScene = menuScene;
        heaterLeft.slider.value = 20;
        heaterRight.slider.value = 20;
        heaterRearRight.slider.value = 20;
        heaterRearLeft.slider.value = 20;
        heaterFront.slider.value = 20;

        ceilingButtons.SetCeilingAnimation((int)CeilingAnimation.SKY);

        lightPanels.SetColor(0.23f, 0.85f, 1f);
    }

    public void SetGameScene()
    {
        if (currentScene != null && currentScene != gameScene)
        {
            currentScene.SetActiveNoInvoke(false);
        }
        currentScene = gameScene;

        heaterLeft.slider.value = 20;
        heaterRight.slider.value = 20;
        heaterRearRight.slider.value = 20;
        heaterRearLeft.slider.value = 20;
        heaterFront.slider.value = 20;

        fanFrontLeft.slider.value = 50;
        fanFrontRight.slider.value = 50;



        lightPanels.SetColor(0.88f,0.007f, 0.34f);
    }

    private void EverythingOff()
    {
        heaterLeft.slider.value = 0;
        heaterRight.slider.value = 0;
        heaterRearRight.slider.value = 0;
        heaterRearLeft.slider.value = 0;
        heaterFront.slider.value = 0;

        fanFrontLeft.slider.value = 0;
        fanFrontRight.slider.value = 0;
        fanRearLeft.slider.value = 0;
        fanRearRight.slider.value = 0;

        scentGrass.slider.value = 0;
        scentMetal.slider.value = 0;
        scentMistySwamp.slider.value = 0;
        scentReptile.slider.value = 0;
        scentSea.slider.value = 0;
        scentSmoke.slider.value = 0;

        ceilingButtons.SetCeilingAnimation((int)CeilingAnimation.OFF);

        lightPanels.SetColor(0, 0, 0);
    }

}
