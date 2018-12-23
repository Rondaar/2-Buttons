using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelectionMenu : MonoBehaviour {

    [SerializeField]
    Skin[] skins;
    [SerializeField]
    GameObject skinButton;
    [SerializeField]
    GameObject playerPref;
	// Use this for initialization
	void Start () 
    {
		foreach(Skin skin in skins)
        {
            GameObject newButton = Instantiate(skinButton, transform);
            newButton.GetComponent<SkinButton>().Initialize(skin,playerPref);
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}
}
