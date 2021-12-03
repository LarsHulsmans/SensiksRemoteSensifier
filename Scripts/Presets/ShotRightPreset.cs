using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensiks.SDK.Shared.SensiksDataTypes;

public class ShotRightPreset : BasePreset
{
    public override IEnumerator StartPreset()
    {
        isPlaying = true;

        scenesManager.heaterRight.slider.value = 100;
        scenesManager.heaterRearRight.slider.value = 100;
        scenesManager.lightPanels.SetColor(LightPanelPosition.RIGHT, 0f, 1f, 0f);

        yield return new WaitForSeconds(0.7f);
        isPlaying = false;
    }
}
