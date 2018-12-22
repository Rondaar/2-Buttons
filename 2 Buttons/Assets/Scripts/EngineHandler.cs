using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineHandler : MonoBehaviour {
    [SerializeField]
    float maxSpeed=5f;
    [SerializeField]
    float force = 200f;
    [SerializeField]
    float rotationSpeed = 2f;
    InputBehaviour input;
    Rigidbody2D rb;
    int dirPrev;
    int lastDir=0;

    public bool CanMove { get; set; }
	// Use this for initialization
	void Start ()
    {
        input = GetComponent<InputBehaviour>();
        rb = GetComponent<Rigidbody2D>();
        CanMove = false;
	}


    // Update is called once per frame
    void FixedUpdate ()
    {
        if (CanMove)
        {
            int dir = input.Right - input.Left;
            rb.velocity = transform.up * rb.velocity.magnitude;
            if (dir != dirPrev)
            {
                // rb.transform.Rotate(dir * Vector3.forward * rotationSpeed);
                if (dir != 0 && lastDir != dir) rb.angularVelocity = 0;
                rb.AddTorque(dir * rotationSpeed, ForceMode2D.Impulse);

                rb.AddForce(transform.up * force * Mathf.Abs(dir), ForceMode2D.Impulse);
            }
            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = maxSpeed * (rb.velocity).normalized;
            }
            dirPrev = dir;
            if (dirPrev != 0)
            {
                lastDir = dirPrev;
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
	}
}
