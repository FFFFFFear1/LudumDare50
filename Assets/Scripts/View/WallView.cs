using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallView : MonoBehaviour
{
    [SerializeField] private Transform _topWallPosition;
    [SerializeField] private Transform _downWallPosition;

    public Transform TopWallPosition { get => _topWallPosition; }
    public Transform DownWallPosition { get => _downWallPosition; }
}
