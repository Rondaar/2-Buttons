using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MyAnimation
{
    [SerializeField]
    AnimationCurve animationCurve;
    [SerializeField]
    float duration=.5f;
    [SerializeField]
    Color[] colors;

    int colIndex=0;
    Color currCol;
    Color nextCol;
    override public void StartAnimation()
    {
        SetupVariables();
        StopAllCoroutines();
        StartCoroutine(Animate());
    }

    void SetupVariables()
    {
        currCol = Camera.main.backgroundColor;
        nextCol = colors[(++colIndex) % colors.Length];
    }

    IEnumerator Animate()
    {
        float time = 0;
        float perc = 0;

        while (perc < 1)
        {
            time += Time.deltaTime;
            perc = time / duration;
            Camera.main.backgroundColor = Color.LerpUnclamped(currCol, nextCol, animationCurve.Evaluate(perc));
            yield return null;
        }

    }
}
