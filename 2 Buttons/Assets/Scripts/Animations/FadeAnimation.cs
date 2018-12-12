using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAnimation : MyAnimation
{

    [SerializeField]
    float duration;
    [SerializeField]
    AnimationCurve animationCurve;
    [SerializeField]
    [Range(0, 1)]
    float finalAlpha=0;

    Image image;
    private void Start()
    {
        image = GetComponent<Image>();

    }
    override public void StartAnimation()
    {
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        float time = 0;
        float perc = 0;
        float startAlpha = image.color.a;
        while (perc < 1)
        {

            time += Time.deltaTime;
            perc = time / duration;
            image.color = new Color(image.color.r,image.color.g,image.color.b,Mathf.LerpUnclamped(startAlpha, finalAlpha, animationCurve.Evaluate(perc)));
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
