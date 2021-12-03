using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresetHolder : MonoBehaviour
{
    private string _presetTitle;
    public string presetTitle
    {
        get
        {
            return _presetTitle;
        }
        set
        {
            _presetTitle = value;
            buttonText.text = _presetTitle;
        }
    }

    [SerializeField]
    private Text buttonText;

    private PresetsManager _manager;
    public PresetsManager Manager
    {
        get
        {
            if(_manager == null)
            {
                _manager = FindObjectOfType<PresetsManager>();
            }
            return _manager;
        }
    }

    public void Execute()
    {
        Manager.StartPreset(presetTitle);
    }
}
