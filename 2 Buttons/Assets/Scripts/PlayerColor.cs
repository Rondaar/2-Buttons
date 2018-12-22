using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
}
