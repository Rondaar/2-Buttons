using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MyAnimation : MonoBehaviour {
    [SerializeField]
    MyAnimation[] nextAnimations;

    public abstract void StartAnimation();
    protected void PlayNextAnim()
    {
        foreach(MyAnimation anim in nextAnimations)
        {
            anim.StartAnimation();
        }
    }
}
