using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroSpriteAnimation : MonoBehaviour
{

    private float pulseStartSize = 0.7f;
    private Coroutine pulseRoutine;
    

    public void TriggerPulse()
    {
        if(pulseRoutine == null)
            pulseRoutine = StartCoroutine(Pulse());
        else
        {
            StopCoroutine(pulseRoutine);
            ResetAnimation();
            pulseRoutine = StartCoroutine(Pulse());
        }
    }

    private void ResetAnimation()
    {
        transform.localPosition = Vector3.zero;
        transform.localScale = Vector3.one;
    }

    private IEnumerator Pulse()
    {
        float timer = 0.0f;
        while (timer < 1.0f)
        {
            timer += 0.1f;
            transform.localScale = new Vector3
                (
                    EaseOutBounce(pulseStartSize, 1, timer),
                    EaseOutBounce(pulseStartSize, 1, timer),
                    1
                );
            yield return new WaitForSeconds(0.03f);
        }

        yield return null;
    }


    private float EaseOutBounce(float start, float end, float value)
    {
        value /= 1f;
        end -= start;
        if (value < (1 / 2.75f))
        {
            return end * (7.5625f * value * value) + start;
        }
        else if (value < (2 / 2.75f))
        {
            value -= (1.5f / 2.75f);
            return end * (7.5625f * (value) * value + .75f) + start;
        }
        else if (value < (2.5 / 2.75))
        {
            value -= (2.25f / 2.75f);
            return end * (7.5625f * (value) * value + .9375f) + start;
        }
        else
        {
            value -= (2.625f / 2.75f);
            return end * (7.5625f * (value) * value + .984375f) + start;
        }
    }
}
