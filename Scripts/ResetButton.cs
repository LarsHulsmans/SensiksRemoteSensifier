using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensiks.SDK.UnityLibrary;

public class ResetButton : MonoBehaviour
{


    public void ResetAll()
    {
        SensiksInstance.Instance.ResetEverything();
    }

    private void OnApplicationQuit()
    {
        SensiksManager.ResetActuators();
    }

}
