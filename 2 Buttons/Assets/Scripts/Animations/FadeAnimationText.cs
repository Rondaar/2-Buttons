using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAnimationText : MyAnimation
{
    [SerializeField]
    float duration;
    [SerializeField]
    AnimationCurve animationCurve;
    [SerializeField]
    [Range(0, 1)]
    float finalAlpha=0;

    Text text;
    private void Start()
    {
        text = GetComponent<Text>();

    }
    override public void StartAnimation()
    {
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        float time = 0;
        float perc = 0;
        float startAlpha = text.color.a;
        while (perc < 1)
        {
            time += Time.deltaTime;
            perc = time / duration;
            text.color = new Color(text.color.r,text.color.g,text.color.b,Mathf.LerpUnclamped(startAlpha, finalAlpha, animationCurve.Evaluate(perc)));
            yield return null;
        }
        PlayNextAnim();
        IsPlaying = false;
    }
}
