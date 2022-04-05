using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AlpfaAnimator : MonoBehaviour
{
    [SerializeField] private CanvasGroup _textCanvasGroup;
    [SerializeField] private float _duration;
    void Start()
    {
        Blink(true);
    }

    private void Blink(bool isVisible)
    {
        float endValue;
        if (isVisible)
            endValue = 0;
        else endValue = 1;
        _textCanvasGroup.DOFade(endValue, _duration).OnComplete(() => Blink(!isVisible));
    }
}
