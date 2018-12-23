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
    protected GameObject ringEffect;

    public CollectibleSpawner MySpawner { get; set; }

    private void Start()
    {
        SpawnRingEffect();
    }

    virtual protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<ScoreController>().Score++;
            collision.GetComponent<TimerHandler>().TimeLeft += timeBonus;
            collision.GetComponent<TrailManager>().IncrementTailTime(.25f);
            MySpawner.Spawn();

            GameMaster.instance.Level++;
            Destroy(gameObject);
        }
    }

    void SpawnRingEffect()
    {
        GameObject instance = Instantiate(ringEffect);
        instance.transform.position = transform.position;

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
        newSound.GetComponent<MySound>().Play();
    }
}
