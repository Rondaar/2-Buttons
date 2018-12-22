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
    [SerializeField]
    GameObject[] stuffToDestroy;
    [SerializeField]
    AudioClip goSnd;
    [SerializeField]
    AudioSource audioSrc;

    public virtual void GameOver() { }

    override public void Action() { Initialize(); }

    protected virtual void Initialize()
    {
        StartCoroutine(Countdown(.5f));
    }
    protected virtual void Begin()
    {
        foreach(GameObject item in stuffToDestroy)
        {
            Destroy(item);
        }
        GameMaster.instance.GameBegin();
    }
    protected IEnumerator Countdown(float tickTime)
    {
        while (countdown > 0)
        {
            countdownText.text = (countdown--).ToString();
            anim.SetTrigger("tick");
            audioSrc.Play();
            yield return new WaitForSeconds(tickTime);
        }
        anim.SetTrigger("tick");
        countdownText.text = "GO";
        audioSrc.clip = goSnd;
        audioSrc.Play();
        yield return new WaitForSeconds(tickTime);
        countdownText.text = "";
        Begin();
    }
}
