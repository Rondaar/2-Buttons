using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : InputBehaviour
{	
	// Update is called once per frame
	void FixedUpdate () {
        Left = Input.GetButton("Fire1")? 0:1 ;
        Right = Input.GetButton("Fire2")? 0:1;
	}
}
