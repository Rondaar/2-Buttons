using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaPingPongText : MyAnimation
{
    Text myText;
	// Use this for initialization
	void Start ()
    {
        myText = GetComponent<Text>();
        myText.color = new Color(myText.color.r, myText.color.g, myText.color.b, 0);
    }

    // Update is called once per frame
    override public void StartAnimation()
    {
        GameMaster.instance.InitRestart();
        StartCoroutine(Animate());
    }
    IEnumerator Animate()
    {
        while(true)
        {
            myText.color = new Color(myText.color.r, myText.color.g, myText.color.b, Mathf.PingPong(Time.time * 2, 1));
            yield return null;
        }
    }
}
