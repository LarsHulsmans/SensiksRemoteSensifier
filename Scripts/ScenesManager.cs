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
        EverythingOff();
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

        ///lightPanels.SetColor(0.23f, 0.85f, 1f);
        StartCoroutine(interpolateLights(1, 0.23f, 0.85f, 1f));
    }

    public void SetGameScene()
    {
        EverythingOff();
        if (currentScene != null && currentScene != gameScene)
        {
            currentScene.SetActiveNoInvoke(false);
        }
        currentScene = gameScene;

        heaterLeft.slider.value = 0;
        heaterRight.slider.value = 0;
        heaterRearRight.slider.value = 0;
        heaterRearLeft.slider.value = 0;
        heaterFront.slider.value = 0;

        fanFrontLeft.slider.value = 70;
        fanFrontRight.slider.value = 70;

        ceilingButtons.SetCeilingAnimation((int)CeilingAnimation.STARS);

        //lightPanels.SetColor(0.88f,0.007f, 0.34f);
        StartCoroutine(interpolateLights(1, 0.88f, 0.2f, 0.4f));
    }


    private IEnumerator interpolateLights(float time, float r, float g, float b)
    {
        float rfrom = lightPanels.leftPicker.CurrentColor.r;
        float gfrom = lightPanels.leftPicker.CurrentColor.g;
        float bfrom = lightPanels.leftPicker.CurrentColor.b;
        Color fromColor = new Color(rfrom, gfrom, bfrom);
        Color toColor = new Color(r, g, b);

        Debug.Log(string.Format("COLOR: {0} {1} {2}", rfrom, gfrom, bfrom));

        float waitTime = time;
        float elapsedTime = 0;

        while (elapsedTime < waitTime)
        {

            float elap = (elapsedTime / waitTime);
            Color currCol = Color.Lerp(fromColor, toColor, elap);

            lightPanels.SetColor(currCol.r, currCol.g, currCol.b);
            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;
            lightPanels.SetColor(r, g, b);
        }

    }

    public void EverythingOff()
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

        //lightPanels.SetColor(0, 0, 0);
    }

}
