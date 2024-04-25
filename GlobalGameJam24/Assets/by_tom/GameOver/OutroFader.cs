using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroFader : MonoBehaviour
{

    [SerializeField] private RectTransform Curtains;
    [SerializeField] private RectTransform LeftCurtains;
    [SerializeField] private RectTransform RightCurtains;

    [SerializeField] private float CurtainUpOffset = 20;
    [SerializeField] private float CurtainDownOffset = 40;

    private float curtainsUpPosition;

    private float inLerpSpeed = 0.14f;
    private float outLerpSpeed = 0.09f;

    private void Start()
    {
        curtainsUpPosition = Curtains.rect.size.y - CurtainUpOffset;
        float requiredCurtainsSize = Curtains.rect.size.y + CurtainUpOffset + CurtainDownOffset;
        // Scale curtain after getting its size to find out how much it has to be scaled in y direction
        Curtains.localScale = new(1.0f, requiredCurtainsSize / Curtains.rect.size.y, 1.0f);
        Curtains.anchoredPosition = Vector3.up * curtainsUpPosition;
    }

    public IEnumerator PerformOutroFade()
    {
        int steps = 30;
        for(int step  = 0; step < steps; step++)
        {

            Curtains.anchoredPosition = Vector3.Lerp(Curtains.anchoredPosition, Vector3.zero, inLerpSpeed);
            LeftCurtains.localScale = Vector3.Lerp(LeftCurtains.localScale, Vector3.one, inLerpSpeed);
            RightCurtains.localScale = Vector3.Lerp(RightCurtains.localScale, Vector3.one, inLerpSpeed);
            yield return new WaitForSeconds(0.03f);
        }
        Curtains.anchoredPosition = Vector3.zero;
        LeftCurtains.localScale= Vector3.one;
        RightCurtains.localScale= Vector3.one;
    }

    public IEnumerator UndoOutroFade()
    {
        int steps = 60;
        for (int step = 0; step < steps; step++)
        {
            Curtains.anchoredPosition = Vector3.Lerp(Curtains.anchoredPosition, Vector3.up * curtainsUpPosition, outLerpSpeed);
            LeftCurtains.localScale = Vector3.Lerp(LeftCurtains.localScale, new Vector3(0.9f,1,1), outLerpSpeed);
            RightCurtains.localScale = Vector3.Lerp(RightCurtains.localScale, new Vector3(0.9f,1,1), outLerpSpeed);
            yield return new WaitForSeconds(0.03f);
        }
        Curtains.anchoredPosition = Vector3.up * curtainsUpPosition;
        LeftCurtains.localScale = new Vector3(0.9f, 1, 1);
        RightCurtains.localScale = new Vector3(0.9f, 1, 1);
    }
}
