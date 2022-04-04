using DG.Tweening;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string WALL = "Wall";
    [SerializeField] private BodyPart[] bodyParts;

    private Rigidbody2D _rigidbody;
    private Camera _camera;

    private float _hp = 100;
    private float _speed;
    private float _score;
    private bool _touching;

    private float _startPosY;

    public Action ChangedHP;
    public Action ChangedSpeed;
    public Action ChangedScore;
    public Action<float> OnObjectHit;


    [SerializeField] private MainMenu _menu;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startPosY = transform.position.y;
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        OnObjectHit += DamagePlayer;
    }
    private void OnDisable()
    {
        OnObjectHit -= DamagePlayer;
    }

    private void Update()
    {
        Speed = _rigidbody.velocity.y;
        Score = (_startPosY - transform.position.y);
    }

   // private void OnMouseDrag()
   // {
   //     _rigidbody.DOMove(_camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)), 0.125f);
   // }

    private void DamagePlayer(float hp)
    {
        HP -= hp;
    }

    public float HP
    {
        get { return _hp; }
        set 
        {
            ChangedHP();
            _hp = value >= 0 ? value : 0;
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
