using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensiks.SDK.UnityLibrary;
using Sensiks.SDK.Shared.SensiksDataTypes;

public class ResetButton : MonoBehaviour
{


    public void ResetAll()
    {
        SensiksInstance.Instance.ResetEverything();
        SensiksInstance.Instance.SetCeilingAnimation(CeilingAnimation.OFF);
    }

    private void OnApplicationQuit()
    {
        SensiksManager.ResetActuators();
    }

}
