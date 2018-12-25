using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelectionMenu : MonoBehaviour {

    [SerializeField]
    Skin[] skins;
    [SerializeField]
    GameObject skinButton;
    [SerializeField]
    GameObject playerPref;
    [SerializeField]
    Text creditsText;
	// Use this for initialization
	void Start () 
    {
		foreach(Skin skin in skins)
        {
            GameObject newButton = Instantiate(skinButton, transform);
            newButton.GetComponent<SkinButton>().Initialize(skin,playerPref,this);
        }
	}
	
	// Update is called once per frame
	public void SetCreditsText()
    {
        creditsText.text = GameData.Credits + " credits";
    }
}
