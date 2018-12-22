using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Input : InputBehaviour
{	
	// Update is called once per frame
	void FixedUpdate () {
        Left = Input.GetKey(KeyCode.LeftArrow)? 0:1 ;
        Right = Input.GetKey(KeyCode.RightArrow)? 0:1;
	}
}
