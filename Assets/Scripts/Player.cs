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
    private float _score;

    private float _startPosY;

    public Action ChangedHP;
    public Action ChangedSpeed;
    public Action ChangedScore;

    [SerializeField] private MainMenu _menu;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startPosY = transform.position.y;
        _camera = Camera.main;
    }

    private void Update()
    {
        Speed = _rigidbody.velocity.y;
        Score = (_startPosY - transform.position.y);
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

    public float Score
    {
        get { return _score; }
        set
        {
            ChangedScore();
            _score = value;
        }
    }

    [ContextMenu("Умереть")]
    public void Death()
    {
        _menu.PostData(PlayerPrefs.GetString("Name"), Score.ToString("f0"));
    }
}
