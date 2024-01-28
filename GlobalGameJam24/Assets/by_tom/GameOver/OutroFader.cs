using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroFader : MonoBehaviour
{

    [SerializeField] private RectTransform Curtains;
    [SerializeField] private RectTransform LeftCurtains;
    [SerializeField] private RectTransform RightCurtains;

    private float CurtainsUpPosition;

    private float inLerpSpeed = 0.14f;
    private float outLerpSpeed = 0.09f;

    private void Start()
    {
        CurtainsUpPosition = Curtains.anchoredPosition.y;
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
            Curtains.anchoredPosition = Vector3.Lerp(Curtains.anchoredPosition, Vector3.up * CurtainsUpPosition, outLerpSpeed);
            LeftCurtains.localScale = Vector3.Lerp(LeftCurtains.localScale, new Vector3(0.9f,1,1), outLerpSpeed);
            RightCurtains.localScale = Vector3.Lerp(RightCurtains.localScale, new Vector3(0.9f,1,1), outLerpSpeed);
            yield return new WaitForSeconds(0.03f);
        }
        Curtains.anchoredPosition = Vector3.up * CurtainsUpPosition;
        LeftCurtains.localScale = new Vector3(0.9f, 1, 1);
        RightCurtains.localScale = new Vector3(0.9f, 1, 1);
    }
}
