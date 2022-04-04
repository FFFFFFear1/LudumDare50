using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _vCam;
    [SerializeField] private float _duration;
    [SerializeField] private float _intensity;

    public static Action OnWallCollide;

    private void OnEnable() => 
        OnWallCollide += ShakeCamera;

    private void OnDisable() => 
        OnWallCollide += ShakeCamera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            ShakeCamera();
    }

    private void ShakeCamera()
    {
        float currIntensity = 0;
        DOTween.To(() => currIntensity, x => currIntensity = x, _intensity, _duration / 2)
            .OnUpdate(() =>
            {
                _vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = currIntensity;
            })
            .OnComplete(() =>
            {
                DOTween.To(() => currIntensity, x => currIntensity = x, 0, _duration / 2)
                    .OnUpdate(() =>
                    {
                        _vCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = currIntensity;
                    });
            });
    }
}
