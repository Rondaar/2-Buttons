using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleColorHandler : MonoBehaviour {

    SpriteRenderer sprRndr;
    Color initColor;

    private void Awake()
    {
        sprRndr = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    void Start () {
        initColor = sprRndr.color;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
