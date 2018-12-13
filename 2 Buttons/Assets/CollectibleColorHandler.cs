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
        ps = GetComponent<ParticleSystem>();
    }
    // Use this for initialization
    void Start () {
        initColor = sprRndr.color;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (player!=null)
          dist = FitInScreenHelper.GetDistance(transform.position, player.transform.position);
        // sprRndr.color = initColor * dist + Color.white*(1-dist)*Color.magenta*(1-dist);

        sprRndr.color = initColor * dist + Color.white * (1 - dist);
        ps.startColor = sprRndr.color;
        
	}
}
