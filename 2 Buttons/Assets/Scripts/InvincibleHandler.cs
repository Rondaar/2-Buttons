using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleHandler : MonoBehaviour {

    public bool Invincible { get; private set; }

    InvincibleAnimation invincAnim;
    // Use this for initialization
    private void Awake()
    {
        invincAnim = GetComponent<InvincibleAnimation>();
    }

    public void InvincibleModeStart()
    {
        Invincible = true;
        invincAnim.StartAnimation();
    }

    public void InvincibleModeEnd()
    {
        Invincible = false;
    }
}
