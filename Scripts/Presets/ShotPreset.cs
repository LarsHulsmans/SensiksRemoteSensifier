using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensiks.SDK.Shared.SensiksDataTypes;

public class ShotPreset : BasePreset
{
    public override IEnumerator StartPreset()
    {
        isPlaying = true;

        scenesManager.lightPanels.SetColor( 0f, 1f, 0f);

        yield return new WaitForSeconds(0.5f);
        isPlaying = false;
    }
}
