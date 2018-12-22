using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathParticlesController : MonoBehaviour {
    [SerializeField]
    GameObject pref;
	
    public void SpawnEffect()
    {
        GameObject instance = Instantiate(pref);
        instance.transform.position = transform.position;
    }
}
