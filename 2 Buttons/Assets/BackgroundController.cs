using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

    [SerializeField]
    Material[] materials;
	// Use this for initialization
	void Awake () {
        GetComponent<Renderer>().material = materials[Random.Range(0, materials.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
