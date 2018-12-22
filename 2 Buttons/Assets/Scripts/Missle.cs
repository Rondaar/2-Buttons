using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour {
    [SerializeField]
    float speed=20f;

    public GameObject MySpawner { get; set; }
	// Use this for initialization
    public void Shoot()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable other =collision.GetComponent<Damageable>();
        if (other!=null && collision.gameObject != MySpawner)
        {
            other.TakeDamage();
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
