using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    [SerializeField]
    float timeBonus=1f;
    [SerializeField]
    GameObject deathEffect;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start ()
    {
        transform.rotation = Quaternion.AngleAxis( Random.Range(0f, 360f),Vector3.forward);
        rb.AddForce(transform.up * 2.4f, ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(-30f,30f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<InvincibleHandler>().Invincible)
            {
                collision.GetComponent<ScoreController>().Score++;
                collision.GetComponent<TimerHandler>().TimeLeft += timeBonus;
                if (deathEffect != null) {
                    GameObject instance = Instantiate(deathEffect);
                    instance.transform.position = transform.position;
                }
                Destroy(gameObject);
            }
            else
            {
                collision.GetComponent<TimerHandler>().TimeLeft -= 100f;
            }
        }
    }
}
