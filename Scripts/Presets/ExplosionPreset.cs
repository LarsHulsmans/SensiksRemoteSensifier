using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensiks.SDK.Shared.SensiksDataTypes;

public class ExplosionPreset : BasePreset
{
    public override IEnumerator StartPreset()
    {
        isPlaying = true;
        SensiksInstance.Instance.SetHeaterIntensity(HeaterPosition.LEFT, 1f);
        SensiksInstance.Instance.SetHeaterIntensity(HeaterPosition.RIGHT, 1f);
        SensiksInstance.Instance.SetHeaterIntensity(HeaterPosition.FRONT, 1f);
        SensiksInstance.Instance.SetHeaterIntensity(HeaterPosition.SEAT_LEFT, 1f);
        SensiksInstance.Instance.SetHeaterIntensity(HeaterPosition.SEAT_RIGHT, 1f);
        yield return new WaitForSeconds(3);

        isPlaying = false;
    }
}
