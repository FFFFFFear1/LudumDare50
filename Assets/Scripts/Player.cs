using DG.Tweening;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D[] rigs;

    private Rigidbody2D _rigidbody;
    private Camera _camera;

    private float _hp = 100;
    private float _speed;

    public Action ChangedHP;
    public Action ChangedSpeed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }

    private void Update()
    {
        Speed = _rigidbody.velocity.y;
    }

    private void OnMouseDrag()
    {
        _rigidbody.DOMove(_camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)), 0.125f);
    }


    public float HP
    {
        get { return _hp; }
        set 
        {
            ChangedHP();
            _hp = value; 
        }
    }

    public float Speed
    {
        get { return _speed; }
        set 
        {
            ChangedSpeed();
            _speed = value; 
        }
    }
}
