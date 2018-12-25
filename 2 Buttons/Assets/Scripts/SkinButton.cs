using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinButton : MonoBehaviour {

    GameObject playerPref;
    Skin mySkin;
    string myKey;
    Text myText;
    SkinSelectionMenu skinSelection;

    private void Awake()
    {
        myText = GetComponentInChildren<Text>();
    }

    public void Initialize(Skin skin,GameObject playerPref,SkinSelectionMenu skinSelection)
    {
        this.skinSelection = skinSelection; 
        mySkin = skin;
        GetComponent<Image>().color = skin.characterColor;
        myKey = skin.characterColor.ToString();
        if (PlayerPrefs.HasKey(myKey) && PlayerPrefs.GetInt(myKey) == 1)
        {
            myText.text = "unlocked";
        }
        else
        {
            myText.text = skin.cost.ToString();
        }
        this.playerPref = playerPref;
    }
    public void SetSkin()
    {
        if (PlayerPrefs.GetInt(myKey) == 1)
        {
            playerPref.GetComponent<SpriteRenderer>().color = mySkin.characterColor;
            playerPref.GetComponentInChildren<TrailRenderer>().colorGradient = mySkin.trailCol;
            Debug.Log(playerPref.GetComponent<SpriteRenderer>().color);
        }
        else if (GameData.Credits>= mySkin.cost)
        {
            GameData.Credits -= mySkin.cost;
            PlayerPrefs.SetInt(myKey, 1);
            myText.text = "unclocked";
            //creditText.text = GameData.Credits.ToString();
            skinSelection.SetCreditsText();
        }

    }
}
