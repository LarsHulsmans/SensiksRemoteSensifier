using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public enum CabinRotateDirection
{
    Horizontal = 0,
    Vertical = 1
}
public class PodRotation : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private RawImage image;
    [SerializeField]
    private Transform podModel;

    private bool OverUIElement = false;
    private bool dragging = false;

    private Vector2 deltaPos = Vector2.zero;

    [SerializeField]
    private float rotationSpeed;



    [Header("Rotation Speed")]
    [SerializeField] private float _rotationSpeed = 1.0f;
    private readonly Vector3 _defaultOrientation = new Vector3(-90, 0, 180);

    private Vector2 _touchPosition = Vector2.zero;


    private void Update()
    {
        if (OverUIElement)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dragging = true;
                deltaPos = Input.mousePosition;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }

        if (dragging)
        {
            _touchPosition = Input.mousePosition;

            Vector2 diff = _touchPosition - deltaPos;

            DoRotate(Vector3.up, (-diff.x * Time.deltaTime) * _rotationSpeed, Space.World);
            DoRotate(Vector3.right, (-diff.y * Time.deltaTime) * _rotationSpeed, Space.Self);

            //podModel.eulerAngles = new Vector3(Mathf.Clamp(podModel.eulerAngles.x, 110, 70), podModel.eulerAngles.y, podModel.eulerAngles.z);
            ClampAngles(-120f, -60f);

            deltaPos = _touchPosition;
        }
    }

    private void ClampAngles(float minAngle, float maxAngle)
    {
        // get relative range +/-
        float relRange = (maxAngle - minAngle) / 2f;

        // calculate offset
        float offset = maxAngle - relRange;

        // convert to a relative value
        Vector3 angles = podModel.eulerAngles;
        float z = ((angles.x + 540) % 360) - 180 - offset;

        // if outside range
        if (Mathf.Abs(z) > relRange)
        {
            angles.x = relRange * Mathf.Sign(z) + offset;
            podModel.eulerAngles = angles;
        }
    }


    private void DoRotate(Vector3 direction, float angle, Space relativeTo)
    {
        podModel.Rotate(direction, angle, relativeTo);
    }

    public void RotateToDefaultRotation()
    {
        podModel.eulerAngles = _defaultOrientation;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        OverUIElement = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OverUIElement = false;
    }
}
