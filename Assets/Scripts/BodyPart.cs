using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    private const int WALL_LAYER = 6;
    private const int PLANK_LAYER = 8;
    private const int PILLOW_LAYER = 9;
    private const int ANVIL_LAYER = 10;
    private const int JUMPPAD_LAYER = 12;
    private const int BALL_LAYER = 13;


    private const float WALL_HIT_DAMAGE = 2.5f;
    private const float PLANK_HIT_DAMAGE = 0.5f;
    private const float ANVIL_HIT_DAMAGE = 1.5f;
    private const float JUMPPAD_HIT_DAMAGE = 2f;
    private const float BALL_HIT_DAMAGE = 0.5f;
    private const float PILLOW_HIT_DAMAGE = 0.2f;
    private const float HIT_COOLDOWN = 3;

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
        { PILLOW_LAYER, PILLOW_HIT_DAMAGE },
        { ANVIL_LAYER, ANVIL_HIT_DAMAGE },
        { JUMPPAD_LAYER, JUMPPAD_HIT_DAMAGE },
        { BALL_LAYER, BALL_HIT_DAMAGE },
    };


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startScale = transform.localScale.x;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_canTouch)
        {
            if (collision.gameObject.layer.Equals(WALL_LAYER) || 
                collision.gameObject.layer.Equals(ANVIL_LAYER) ||
                collision.gameObject.layer.Equals(PILLOW_LAYER) ||
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
