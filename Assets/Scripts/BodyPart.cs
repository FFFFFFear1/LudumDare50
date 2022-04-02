using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    [SerializeField] private float _maxScale;


    private float _startScale;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startScale = transform.localScale.x;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals(6))
        {
            if (transform.localScale.x > _maxScale)
            {
                return;
            }
            transform.DOScale(transform.localScale.x + 0.2f, 1);
        }
    }

    private void OnMouseDrag()
    {
        //_rigidbody.DOMove(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)), 0.125f);
    }
}
