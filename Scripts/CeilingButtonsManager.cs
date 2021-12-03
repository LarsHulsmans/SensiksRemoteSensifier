using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensiks.SDK.Shared.SensiksDataTypes;

public class CeilingButtonsManager : MonoBehaviour
{
    [SerializeField]
    private ButtonActivation forest;
    [SerializeField]
    private ButtonActivation sky;
    [SerializeField]
    private ButtonActivation sun;
    [SerializeField]
    private ButtonActivation stars;
    [SerializeField]
    private ButtonActivation off;


    private ButtonActivation activeAnimation;


    /*
    0 = off
    1 = stars
    2 = sky
    3 = forest
    4 = sun
    */

    private void Start()
    {
        activeAnimation = off;
        activeAnimation.SetActiveNoInvoke(true);
    }

    public void SetCeilingAnimation(int anim)
    {
        activeAnimation.SetActiveNoInvoke(false);
        SensiksInstance.Instance.SetCeilingAnimation((CeilingAnimation)anim);
        switch ((CeilingAnimation)anim)
        {
            case CeilingAnimation.FOREST:
                forest.SetActiveNoInvoke(true);
                activeAnimation = forest;
                break;
            case CeilingAnimation.SKY:
                sky.SetActiveNoInvoke(true);
                activeAnimation = sky;
                break;
            case CeilingAnimation.STARS:
                stars.SetActiveNoInvoke(true);
                activeAnimation = stars;
                break;
            case CeilingAnimation.SUN:
                sun.SetActiveNoInvoke(true);
                activeAnimation = sun;
                break;
            case CeilingAnimation.OFF:
                off.SetActiveNoInvoke(true);
                activeAnimation = off;
                break;
        }
    }
}
