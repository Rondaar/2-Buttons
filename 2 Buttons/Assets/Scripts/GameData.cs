using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    const string highScoreKey="HighScore";
    const string creditsKey = "Credits";

    public static int HighScore 
    {
        get
        {
            return PlayerPrefs.HasKey(highScoreKey) ? PlayerPrefs.GetInt(highScoreKey) : 0;
        }
        set
        {
            PlayerPrefs.SetInt(highScoreKey,value);
        }
    }

    public static int Credits
    {
        get
        {
            return PlayerPrefs.HasKey(creditsKey) ? PlayerPrefs.GetInt(creditsKey) : 0;
        }
        set
        {
            PlayerPrefs.SetInt(creditsKey, value);
        }
    }

}
