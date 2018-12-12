﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour {

    [SerializeField]
    protected GameObject prefab;

    public abstract void Spawn();
}
