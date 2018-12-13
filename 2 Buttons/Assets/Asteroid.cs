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
        rb.AddTorque(Random.Range(15f,30f));
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T))
        {
            
            Debug.Log("asd");
        }
    }
}
