using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleAnimation : MyAnimation 
{

    [SerializeField]
    float duration;

    Color defaultColor;
    Color invincibleColor = Color.white;
    SpriteRenderer sprRndr;
    void Awake()
    {
        SetupVariables();
        sprRndr = GetComponent<SpriteRenderer>();
    }
    override public void StartAnimation()
    {
        StopAllCoroutines();
        StartCoroutine(Animate());
    }

    void SetupVariables()
    {
        defaultColor = GetComponent<SpriteRenderer>().color;
        if(defaultColor == Color.white)
        {
            invincibleColor = Color.red;
        }
    }

    IEnumerator Animate()
    {

        float time = 0;
        float perc = 0;

        while (perc < 1)
        {
            time += Time.deltaTime;
            perc = time / duration;

            Debug.Log(perc);
            sprRndr.color = Color.Lerp(defaultColor, invincibleColor, Mathf.PingPong(perc*20f,1));

            yield return null;
        }
        while(sprRndr.color!=defaultColor)
        {
            sprRndr.color = Color.Lerp(sprRndr.color, defaultColor, Mathf.Clamp01(Time.time));
            yield return null;
        }
        yield return new WaitForSeconds(.6f);
        GetComponent<InvincibleHandler>().InvincibleModeEnd();
        IsPlaying = false;
    }
}
