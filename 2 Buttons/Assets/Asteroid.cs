using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

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
            collision.GetComponent<TimerHandler>().TimeLeft -= 100f;
        }
    }
}
