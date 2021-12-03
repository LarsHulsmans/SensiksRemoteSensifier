using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BasePreset
{
    public bool isPlaying = false;

    private ScenesManager _scenesManager;
    public ScenesManager scenesManager
    {
        get
        {
            if (_scenesManager == null)
            {
                _scenesManager = MonoBehaviour.FindObjectOfType<ScenesManager>();
            }
            return _scenesManager;
        }
    }
    public virtual IEnumerator StartPreset()
    {
        yield return null;
    }
}
