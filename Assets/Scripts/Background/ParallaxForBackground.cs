using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxForBackground : MonoBehaviour
{
    [SerializeField] private float parallaxEffect;
    public GameObject cam;
    private float startPosX;

    void Start()
    {
        startPosX = transform.position.x;
    }

    void Update()
    {
        float distX = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startPosX + distX, transform.position.y, transform.position.z);
    }
}
