using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour {
    [SerializeField]
    float angularVelocityTreshold = 500;
    [SerializeField]
    GameObject fieldPrefab;

    bool ready=false;
    float chargingTime = 0;
    Rigidbody2D rb;
    // Use this for initialization
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start ()
    {
	    	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Mathf.Abs(rb.angularVelocity) > angularVelocityTreshold)
        {
            ready = true;
            chargingTime += Time.deltaTime;
        }
        if (ready && Mathf.Abs(rb.angularVelocity) < 300)
        {
            ready = false;
            Attack(chargingTime);
            chargingTime = 0;         
        }
	}

    void Attack(float force)
    {
        if (force>3)
        {
            force = 3;
        }
        GameObject field = Instantiate(fieldPrefab);
        field.transform.position = transform.position;
        field.transform.localScale = Vector3.one * force * 5;
    }
}
