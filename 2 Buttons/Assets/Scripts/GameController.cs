using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class GameController : Option {
    [SerializeField]
    Animator anim;
    [SerializeField]
    Text countdownText;
    int countdown = 3;

    public virtual void GameOver() { }

    override public void Action() { Initialize(); }

    protected virtual void Initialize()
    {
        StartCoroutine(Countdown(.5f));
    }
    protected virtual void Begin()
    {
        GameMaster.instance.GameBegin();
    }
    protected IEnumerator Countdown(float tickTime)
    {
        while (countdown > 0)
        {
            countdownText.text = (countdown--).ToString();
            anim.SetTrigger("tick");
            yield return new WaitForSeconds(tickTime);
        }
        anim.SetTrigger("tick");
        countdownText.text = "GO";
        yield return new WaitForSeconds(tickTime);
        countdownText.text = "";
        Begin();
    }
}
