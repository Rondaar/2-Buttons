using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDamageable : Damageable
{
    public override void TakeDamage()
    {
        Destroy(gameObject);
    }
}
