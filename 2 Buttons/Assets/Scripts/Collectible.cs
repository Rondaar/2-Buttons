using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    [SerializeField]
    float timeBonus = 3.5f;

    public CollectibleSpawner MySpawner { get; set; }

    public void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<ScoreController>().Score++;
            collision.GetComponent<TimerHandler>().TimeLeft += timeBonus;
            collision.GetComponent<TrailManager>().IncrementTailTime(.25f);
            MySpawner.Spawn();
            Destroy(gameObject);
        }
    }
}
