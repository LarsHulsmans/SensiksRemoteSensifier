using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresetsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject PresetButtonPrefab;

    private Dictionary<string, BasePreset> presets = new Dictionary<string, BasePreset>();

    private Dictionary<string, ButtonActivation> buttons = new Dictionary<string, ButtonActivation>();

    private KeyValuePair<string, BasePreset> currentlyPlaying = new KeyValuePair<string, BasePreset>("",null);

    public void Start()
    {
        presets.Add("Explosion", new ExplosionPreset());
        presets.Add("Shot left", new ShotLeftPreset());
        presets.Add("Shot right", new ShotRightPreset());
        presets.Add("Shot", new ShotPreset());
        BuildButtons();
    }

    private void BuildButtons()
    {
        foreach(KeyValuePair<string, BasePreset> preset in presets)
        {
            //generate buttons
            GameObject presetButton = GameObject.Instantiate(PresetButtonPrefab, this.transform);
            presetButton.GetComponent<PresetHolder>().presetTitle = preset.Key;
            buttons.Add(preset.Key ,presetButton.GetComponent<ButtonActivation>());
        }
    }


    public void StartPreset(string presetID)
    {
        if (presets.ContainsKey(presetID))
        {
            SensiksInstance.Instance.StashCurrentValues();
            SetAllButtonsActive(false);
            buttons[presetID].SetActiveNoInvoke(true);
            currentlyPlaying = new KeyValuePair<string, BasePreset>(presetID, presets[presetID]);
            StartCoroutine(presets[presetID].StartPreset());

        }
    }

    public void SetAllButtonsActive(bool active)
    {
        foreach(KeyValuePair<string, ButtonActivation> button in buttons)
        {
            button.Value.GetComponent<Button>().interactable = active;
        }
    }

    private void Update()
    {
        if(currentlyPlaying.Value != null)
        {
            if (!currentlyPlaying.Value.isPlaying)
            {
                //preset done
                SensiksInstance.Instance.PopStashedValues();
                buttons[currentlyPlaying.Key].SetActiveNoInvoke(false);
                SetAllButtonsActive(true);

                currentlyPlaying = new KeyValuePair<string, BasePreset>("", null);
            }
        }
    }


}
