using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideInAnimation : MyAnimation {

    [SerializeField]
    Vector3 startScale;
    [SerializeField]
    Vector3 startPosition;
    [SerializeField]
    AnimationCurve animationCurve;
    [SerializeField]
    float duration;

    Vector3 endScale;
    Vector3 endPosition;
    private void Awake()
    {
        SetupVariables();
        transform.localPosition = startPosition;
        transform.localScale = startScale;
    }
    override public void StartAnimation()
    {
        StartCoroutine(Animate());
    }

    void SetupVariables()
    {
        endScale = transform.localScale;
        endPosition = transform.localPosition;
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

    }
}
