using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseAnimation : MyAnimation {

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
    Image image;
    Color endColor;

    override public void StartAnimation()
    {
        SetupVariables();
        StartCoroutine(Animate());
    }

    void SetupVariables()
    {
        startScale = transform.localScale;
        startPosition = transform.localPosition;
        image = GetComponent<Image>();
    }

    IEnumerator Animate()
    {
        float time = 0;
        float perc = 0;
        endColor = image.color;
        endColor.a = 0;
        Text[] myTexts =GetComponentsInChildren<Text>();
        foreach (Text text in myTexts)
        {
            text.text ="";
        }
        while (perc < 1)
        {

            time += Time.deltaTime;
            perc = time / duration;
            image.color = Color.Lerp(Color.white, endColor, animationCurve.Evaluate(perc));
            
            transform.localPosition = Vector3.LerpUnclamped(startPosition, endPosition, animationCurve.Evaluate(perc));
            transform.localScale = Vector3.LerpUnclamped(startScale, endScale, animationCurve.Evaluate(perc));
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
