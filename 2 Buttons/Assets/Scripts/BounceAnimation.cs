using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceAnimation : MyAnimation
{

    [SerializeField]
    Vector3 endScale;
    [SerializeField]
    AnimationCurve animationCurve;
    [SerializeField]
    float duration;

    Vector3 defaultScale;
    private void Awake()
    {
        SetupVariables();
    }
    override public void StartAnimation()
    {
        foreach (MyAnimation anim in GetComponents<MyAnimation>())
        {
            anim.StopAllCoroutines();
        }
        if (gameObject.activeSelf)
        {
            StartCoroutine(Animate());
        }
    }

    void SetupVariables()
    {
        defaultScale = transform.localScale;
    }

    IEnumerator Animate()
    {
        transform.localScale = endScale;
        float time = 0;
        float perc = 0;

        while (perc < 1)
        {
            time += Time.deltaTime;
            perc = time / duration;
            transform.localScale = Vector3.LerpUnclamped(endScale, defaultScale, animationCurve.Evaluate(perc));
            yield return null;
        }
        IsPlaying = false;
        PlayNextAnim();
    }
}
