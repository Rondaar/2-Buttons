using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleHandler : MonoBehaviour {

    Animator anim;

    public bool Invincible { get; private set; }
    // Use this for initialization
    void Awake ()
    {
        anim = GetComponent<Animator>();
	}
	
    public void InvincibleModeStart()
    {
        Invincible = true;
        anim.SetTrigger("invincible");
    }

    public void InvincibleModeEnd()
    {
        Invincible = false;
    }
}
