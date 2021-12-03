using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonActivation : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnClick;

    [SerializeField]
    private Image radioImage;

    [SerializeField]
    private Sprite buttonOff;
    [SerializeField]
    private Sprite buttonOn;


    [SerializeField]
    private bool active;


    public void ButtonClicked()
    {
        this.active = !this.active;

        this.OnClick.Invoke();
    }

    private void Update()
    {
        if (this.active)
        {
            this.radioImage.sprite = buttonOn;
        }
        else
        {
            this.radioImage.sprite = buttonOff;
        }
    }

    public void SetActiveInvoke(bool active)
    {
        this.active = active;
        this.OnClick.Invoke();
    }

    public void SetActiveNoInvoke(bool active)
    {
        this.active = active;
    }

}
