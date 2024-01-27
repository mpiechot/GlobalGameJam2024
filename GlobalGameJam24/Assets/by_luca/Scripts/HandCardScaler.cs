using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class HandCardScaler : MonoBehaviour
{
    [SerializeField]
    private float _growDuration = 0.5f;

    [SerializeField]
    private Vector3 _growOffset = new(0.0f, 10.0f, 0.0f);

    [SerializeField]
    private Vector3 _growScale = new(1.1f, 1.1f, 0.0f);

    [SerializeField]
    private Vector3 _spriteGrowScale = new(3.0f, 3.0f, 0.0f);

    [SerializeField]
    private float _growOpacity = 0.6f;

    [SerializeField]
    private float _shrinkDuration = 0.1f;

    [Space]

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private TMP_Text _text;

    [SerializeField]
    private Transform _spriteTransform;


    private Vector3 _initialPos;
    private Vector3 _initialSpriteScale;

    private Tween _visualTweenScale;
    private Tween _visualTweenPos;
    private Tween _visualTweenColor1;
    private Tween _visualTweenColor2;

    private Tween _visualTweenSpriteScale;

    void Start()
    {
        _initialPos = transform.position;
        _initialSpriteScale = _spriteTransform.localScale;

        // Invoke(nameof(GrowVisuals), 1.0f);
        // Invoke(nameof(ShrinkVisuals), 5.0f);
    }

    public void GrowVisuals()
    {
        StopTweens();

        _visualTweenPos = transform.DOMove(_initialPos + _growOffset, _growDuration)
                                    .SetEase(Ease.OutQuad);
        _visualTweenScale = transform.DOScale(_growScale, _growDuration)
                                    .SetEase(Ease.OutQuad);

        Debug.Log(_spriteTransform.transform.localScale);
        _visualTweenSpriteScale = _spriteTransform.transform.DOScale(_spriteGrowScale, _growDuration)
                                            .SetEase(Ease.OutQuad);

        _visualTweenColor1 = _spriteRenderer.DOColor(ColorWithOpacity(_spriteRenderer.color, _growOpacity), 1.0f)
                                            .SetEase(Ease.OutQuad);
        _visualTweenColor2 = _text.DOColor(ColorWithOpacity(_text.color, _growOpacity), 1.0f)
                                            .SetEase(Ease.OutQuad);
    }

    public void ShrinkVisuals()
    {
        StopTweens();

        _visualTweenPos = transform.DOMove(_initialPos, _shrinkDuration)
                                    .SetEase(Ease.OutQuad);
        _visualTweenScale = transform.DOScale(Vector3.one, _shrinkDuration)
                                    .SetEase(Ease.OutQuad);
        
        _visualTweenSpriteScale = _spriteTransform.transform.DOScale(_initialSpriteScale, _shrinkDuration)
                                    .SetEase(Ease.OutQuad);

        _visualTweenColor1 = _spriteRenderer.DOColor(ColorWithOpacity(_spriteRenderer.color, 1.0f), _shrinkDuration)
                                    .SetEase(Ease.OutQuad);
        _visualTweenColor2 = _text.DOColor(ColorWithOpacity(_text.color, 1.0f), _shrinkDuration)
                                            .SetEase(Ease.OutQuad);
    }

    private void StopTweens()
    {
        if (_visualTweenScale != null && _visualTweenScale.IsActive())
        {
            _visualTweenScale.Kill();
        }

        if (_visualTweenPos != null && _visualTweenPos.IsActive())
        {
            _visualTweenPos.Kill();
        }

        if (_visualTweenSpriteScale != null && _visualTweenPos.IsActive())
        {
            _visualTweenPos.Kill();
        }

        if (_visualTweenColor1 != null && _visualTweenColor1.IsActive())
        {
            _visualTweenColor1.Kill();
        }

        if (_visualTweenColor2 != null && _visualTweenColor2.IsActive())
        {
            _visualTweenColor2.Kill();
        }
    }

    private Color ColorWithOpacity(Color color, float opacity) => new(color.r, color.g, color.b, opacity);
}
