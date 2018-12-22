using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleColorHandler : MonoBehaviour {

    SpriteRenderer sprRndr;
    Color initColor;
    GameObject player;
    ParticleSystem ps;
    float dist;

    private void Awake()
    {
        sprRndr = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    void Start () {
        initColor = sprRndr.color;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length>1)
        {
            sprRndr.color = Color.white;
            Destroy(this);
        }
        else
        {
            player = players[0];
        }
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player!=null)
          dist = FitInScreenHelper.GetDistance(transform.position, player.transform.position);

        sprRndr.color = initColor * dist + Color.white * (1 - dist);
	}
}
