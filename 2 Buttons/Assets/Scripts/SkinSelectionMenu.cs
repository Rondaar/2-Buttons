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
    [SerializeField]
    GameObject buySkinGui;
    [SerializeField]
    GameObject skinSelectionGui;
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
        creditsText.text =  "credits: " + GameData.Credits;
    }

    public void DispBuySkin()
    {
        buySkinGui.SetActive(true);
        skinSelectionGui.SetActive(false);
    }

    public void ReturnToSkinSelection()
    {
        buySkinGui.SetActive(false);
        skinSelectionGui.SetActive(true);
    }
}
