using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensiks.SDK.Shared.SensiksDataTypes;

public class ShotLeftPreset : BasePreset
{


    public override IEnumerator StartPreset()
    {
        isPlaying = true;

        scenesManager.heaterLeft.slider.value = 100;
        scenesManager.heaterRearLeft.slider.value = 100;
        scenesManager.lightPanels.SetColor(LightPanelPosition.LEFT, 0f, 1f, 0f);

        yield return new WaitForSeconds(0.3f);
        isPlaying = false;
    }
}
