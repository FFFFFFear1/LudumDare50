using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromUI : MonoBehaviour
{
    public PlatformType type;
    private float angle;

    private void Update()
    {
        angle = Input.GetAxis("Mouse ScrollWheel") * 30;
        transform.Rotate(new Vector3( 0, 0, angle), 30);

        transform.DOMove(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0), 0.025f);

        if (!Input.GetMouseButton(0)) Destroy(gameObject);
        if (Input.GetMouseButtonDown(1)) Destroy(gameObject);
    }

    public float GetAngle
    {
        get => GetComponent<RectTransform>().eulerAngles.z;
    }
}