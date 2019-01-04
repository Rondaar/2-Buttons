using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    Color defaultColor;
    RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        SetupVariables();
        if (GetComponent<Image>() != null)
            defaultColor = GetComponent<Image>().color;
    }
    private void Start()
    {
        rectTransform.anchoredPosition = startPosition;
        transform.localScale = startScale;

    }
    override public void StartAnimation()
    {
        foreach(MyAnimation anim in GetComponents<MyAnimation>())
        {
            anim.StopAllCoroutines();
        }
        Button button = GetComponent<Button>();
        if (button)
        {
            button.interactable = true;
        }
        if (defaultColor != null && GetComponent<Image>())
        {
            GetComponent<Image>().color = defaultColor;
        }
        foreach(Text text in GetComponentsInChildren<Text>())
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        }
        StartCoroutine(Animate());
    }

    void SetupVariables()
    {
        endScale = transform.localScale;
        //endPosition = transform.localPosition;
        endPosition = rectTransform.anchoredPosition;
    }

    IEnumerator Animate()
    {
 
        float time = 0;
        float perc = 0;

        while (perc<1)
        {
            time += Time.deltaTime;
            perc = time / duration;
            rectTransform.anchoredPosition = Vector3.LerpUnclamped(startPosition, endPosition, animationCurve.Evaluate(perc));
            transform.localScale = Vector3.LerpUnclamped(startScale, endScale, animationCurve.Evaluate(perc));
            yield return null;
        }
        IsPlaying = false;
        PlayNextAnim();
    }
}
