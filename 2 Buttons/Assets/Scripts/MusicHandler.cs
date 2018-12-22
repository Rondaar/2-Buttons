using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour {
    #region singleton
    public static MusicHandler musicHandler;
    private void Awake()
    {
        if(musicHandler==null)
        {
            musicHandler = this;
            GetComponent<AudioSource>().Play();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

}
