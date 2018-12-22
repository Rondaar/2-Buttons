using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleCollectible : Collectible
{

    override protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameMaster.instance.Level++;
            collision.GetComponent<ScoreController>().Score++;
            collision.GetComponent<TimerHandler>().TimeLeft += timeBonus;
            collision.GetComponent<TrailManager>().IncrementTailTime(.25f);
            MySpawner.Spawn();
            GameObject instance = Instantiate(deathEffect);
            instance.transform.position = transform.position;
            collision.GetComponent<InvincibleHandler>().InvincibleModeStart();
            Destroy(gameObject);

            AudioSource audio = GetComponent<AudioSource>();
            GameObject newSound = Instantiate(sound);
            newSound.GetComponent<AudioSource>().clip = audio.clip;
            newSound.GetComponent<AudioSource>().pitch *= Mathf.Pow(1.05946f, 7);
            GameMaster.instance.Level++;
            newSound.GetComponent<MySound>().Play();
        }
    }
}
