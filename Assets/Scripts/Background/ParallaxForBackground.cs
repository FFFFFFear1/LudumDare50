﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxForBackground : MonoBehaviour
{
    [SerializeField] private float parallaxEffect;
    [SerializeField] private GameObject cam;
    private float startPosX;

    void Start()
    {
        startPosX = transform.position.x;
        cam = Camera.main.gameObject;
    }

    void Update()
    {
        if (!cam)
        {
            cam = Camera.main.gameObject;
        }
        else
        {
            float distX = (cam.transform.position.x * parallaxEffect);

            transform.position = new Vector3(startPosX + distX, transform.position.y, transform.position.z);
        }
    }
}
