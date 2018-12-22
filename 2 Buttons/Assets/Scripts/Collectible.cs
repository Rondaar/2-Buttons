using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField]
    protected GameObject sound;

    [SerializeField]
    protected float timeBonus = 3.5f;
    [SerializeField]
    protected GameObject deathEffect;

    public CollectibleSpawner MySpawner { get; set; }

    virtual protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<ScoreController>().Score++;
            collision.GetComponent<TimerHandler>().TimeLeft += timeBonus;
            collision.GetComponent<TrailManager>().IncrementTailTime(.25f);
            MySpawner.Spawn();
            GameObject instance = Instantiate(deathEffect);
            instance.transform.position = transform.position;
            Destroy(gameObject);
            AudioSource audio = GetComponent<AudioSource>();
            GameObject newSound = Instantiate(sound);
            newSound.GetComponent<AudioSource>().clip = audio.clip;
            int n = (GameMaster.instance.Level % 5);
            switch (n)
            {
                case 0:
                    n = 0;
                    break;
                case 1:
                    n = 2;
                    break;
                case 2:
                    n = 4;
                    break;
                case 3:
                    n = 5;
                    break;

                default:
                    n = 7;
                    break;
            }
            newSound.GetComponent<AudioSource>().pitch *= Mathf.Pow(1.05946f, n);
            GameMaster.instance.Level++;
            newSound.GetComponent<MySound>().Play();
        }
    }
}
