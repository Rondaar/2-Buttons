using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosAndScaleAnimation : MyAnimation {

    [SerializeField]
    Vector3 endScale;
    [SerializeField]
    Vector3 endPosition;
    [SerializeField]
    AnimationCurve animationCurve;
    [SerializeField]
    float duration;

    Vector3 startScale;
    Vector3 startPosition;

    override public void StartAnimation()
    {
        SetupVariables();
        StartCoroutine(Animate());
    }

    void SetupVariables()
    {
        startScale = transform.localScale;
        startPosition = transform.localPosition;
    }

    IEnumerator Animate()
    {
        float time = 0;
        float perc = 0;

        while (perc<1)
        {

            time += Time.deltaTime;
            perc = time / duration;
            transform.localPosition = Vector3.LerpUnclamped(startPosition, endPosition, animationCurve.Evaluate(perc));
            transform.localScale = Vector3.LerpUnclamped(startScale, endScale, animationCurve.Evaluate(perc));
            yield return null;
        }
        IsPlaying = false;
    }
}
