using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMobile : InputBehaviour {


	// Update is called once per frame
	void Update ()
    {
        if (Input.touchCount > 0)
        {
            
            var touch = Input.GetTouch(Input.touchCount-1);
            if (touch.position.x < Screen.width / 2)
            {
                Right = 1;
                Left = 0;
            }
            else if (touch.position.x > Screen.width / 2)
            {
                Left = 1;
                Right = 0;
            }
        }else
        {
            Left = 0;
            Right = 0;
        }
    }
}
