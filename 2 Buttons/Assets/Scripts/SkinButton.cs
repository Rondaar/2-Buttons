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
    static SkinButton selectedSkinButton;
    BounceAnimation bounceAnim;

    private void Awake()
    {
        myText = GetComponentInChildren<Text>();
        bounceAnim = GetComponent<BounceAnimation>();
    }

    public void Initialize(Skin skin, GameObject playerPref, SkinSelectionMenu skinSelection)
    {
        this.skinSelection = skinSelection;
        mySkin = skin;
        GetComponent<Image>().color = skin.characterColor;
        myKey = skin.characterColor.ToString();
 
        if (PlayerPrefs.HasKey(myKey))
        {
            if (PlayerPrefs.GetInt(myKey) == 1)
                myText.text = "unlocked";
            else if (PlayerPrefs.GetInt(myKey) == 2)
            {
                myText.text = "selected";
                playerPref.GetComponent<SpriteRenderer>().color = mySkin.characterColor;
                playerPref.GetComponentInChildren<TrailRenderer>().colorGradient = mySkin.trailCol;
                if (selectedSkinButton != null)
                {
                    selectedSkinButton.myText.text = "unlocked";
                    PlayerPrefs.SetInt(selectedSkinButton.myKey, 1);
                }
                selectedSkinButton = this;
            }
        }
        else
        {
            myText.text = skin.cost.ToString();
        }
        this.playerPref = playerPref;
    }
    public void SkinTransaction()
    {
        if (PlayerPrefs.GetInt(myKey) == 1)
        {
            SetSkin();
        }
        else if (GameData.Credits >= mySkin.cost)
        {
            //disp buy skin
            skinSelection.DispBuySkin();
            FindObjectOfType<SkinTransactionButton>().MySkinButton = this;
        }

    }

    public void SetSkin()
    {
        playerPref.GetComponent<SpriteRenderer>().color = mySkin.characterColor;
        playerPref.GetComponentInChildren<TrailRenderer>().colorGradient = mySkin.trailCol;
        myText.text = "selected";
        PlayerPrefs.SetInt(myKey, 2);
        if (selectedSkinButton != null)
        {
            selectedSkinButton.myText.text = "unlocked";
            PlayerPrefs.SetInt(selectedSkinButton.myKey, 1);
        }
        selectedSkinButton = this;
        bounceAnim.StartAnimation();
       
        PlayerPrefs.SetString(GameMaster.instance.GetCurrSkinKey(), myKey);
    }

    public void BuySkin()
    {
        GameData.Credits -= mySkin.cost;
        skinSelection.SetCreditsText();
        SetSkin();
    }
}
