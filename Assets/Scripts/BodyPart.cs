using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    private const int WALL_LAYER = 6;
    private const int PLANK_LAYER = 8;
    private const int WALL_HIT_DAMAGE = 6;
    private const int PLANK_HIT_DAMAGE = 1;
    private const int HIT_COOLDOWN = 3;
    [SerializeField] private float _maxScale;
    [SerializeField] private Player _player;

    private bool _stopScale;
    private float _startScale;
    private Rigidbody2D _rigidbody;
    private bool _canTouch =true;

    private Dictionary<int, float> _damageByLayer = new Dictionary<int, float>()
    {
        { WALL_LAYER, WALL_HIT_DAMAGE },
        { PLANK_LAYER, PLANK_HIT_DAMAGE },
    };


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startScale = transform.localScale.x;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals(WALL_LAYER))
        {
           

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_canTouch)
        {
            if (collision.gameObject.layer.Equals(WALL_LAYER)||
                collision.gameObject.layer.Equals(PLANK_LAYER))
            {
                Hit(_damageByLayer[collision.gameObject.layer]);
            }
        }
    }
    private void OnMouseDrag()
    {
        //_rigidbody.DOMove(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)), 0.125f);
    }
    private void Hit(float dmgVariant)
    {
        StartCoroutine(HitCooldown());
        //ChangeScale();
        float dmg = dmgVariant * (Math.Abs(_player.Speed) / 10);
        _player.OnObjectHit?.Invoke(dmg);
    }
    private void ChangeScale()
    {
        if (transform.localScale.x > _maxScale)
        {
            _stopScale = true;
            DOVirtual.DelayedCall(10, () => transform.DOScale(_startScale, 2), false).OnComplete(() =>
            {
                _stopScale = false;
            });
            return;
        }
        if (!_stopScale)
            transform.DOScale(transform.localScale.x + 0.1f, 1);
    }
    private IEnumerator HitCooldown()
    {
        _canTouch = false;
        yield return new WaitForSeconds(HIT_COOLDOWN);
        _canTouch = true;
    }
}
