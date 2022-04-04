using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEffectsManager : MonoBehaviour
{
  [SerializeField] private GameObject _stoneCrashEffect;
  private void OnCollisionEnter2D(Collision2D col)
  {
    if (col.gameObject.layer == 6)
    {
      CameraShaker.OnWallCollide?.Invoke();
      ContactPoint2D point = col.contacts[0];
      Vector2 spawnPoint = point.point;
      Instantiate(_stoneCrashEffect, spawnPoint, Quaternion.identity);
    }
  }
}
