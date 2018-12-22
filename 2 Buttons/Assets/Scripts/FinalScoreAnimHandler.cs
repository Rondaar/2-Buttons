using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScoreAnimHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameMaster.instance.OnGameOver += PlayAnim;
	}

    private void OnDisable()
    {
        GameMaster.instance.OnGameOver -= PlayAnim;
    }
    // Update is called once per frame
    void PlayAnim()
    {
        GetComponent<MyAnimation>().StartAnimation();
    }
}
