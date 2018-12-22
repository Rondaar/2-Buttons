using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageable : Damageable
{
    TimerHandler timeHandler;
    private void Awake()
    {
        timeHandler = GetComponent<TimerHandler>();
    }
    public override void TakeDamage()
    {
        timeHandler.TimeLeft -= .5f;
    }
}
