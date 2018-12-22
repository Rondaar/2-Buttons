using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAnimation : MonoBehaviour 
{
    [SerializeField]
    MyAnimation[] nextAnimations;

    public bool IsPlaying 
    {
        get;
        set;
    }

    public virtual void StartAnimation()
    {
        IsPlaying = true;
    }
    protected void PlayNextAnim()
    {
        foreach(MyAnimation anim in nextAnimations)
        {
            anim.StartAnimation();
        }
    }
}
