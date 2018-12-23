using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinButton : MonoBehaviour {

    GameObject playerPref;
    Skin mySkin;

    public void Initialize(Skin skin,GameObject playerPref)
    {
        mySkin = skin;
        GetComponent<Image>().color = skin.characterColor;
        this.playerPref = playerPref;
    }
    public void SetSkin()
    {
        playerPref.GetComponent<SpriteRenderer>().color = mySkin.characterColor;
        playerPref.GetComponentInChildren<TrailRenderer>().colorGradient = mySkin.trailCol;
        Debug.Log(playerPref.GetComponent<SpriteRenderer>().color);
    }
}
