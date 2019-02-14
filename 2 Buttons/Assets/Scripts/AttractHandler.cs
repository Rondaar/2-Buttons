using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractHandler : MonoBehaviour {
    [SerializeField]
    float angularVelocityTreshold = 500;
    bool ready=false;
    float chargingTime = 0;
    Rigidbody2D rb;
    // Use this for initialization
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Mathf.Abs(rb.angularVelocity) > angularVelocityTreshold)
        {
            ready = true;
            chargingTime += Time.deltaTime;
            Attract();
        }
        if (ready && Mathf.Abs(rb.angularVelocity) < 300)
        {
            ready = false;
            chargingTime = 0;         
        }
	}

 
    void Attract()
    {
        foreach(GameObject attractable in GameObject.FindGameObjectsWithTag("Attractable"))
        {
            attractable.GetComponent<Rigidbody2D>().AddForce((FitInScreenHelper.GetDirection(transform.position, attractable.transform.position)*35f*Time.deltaTime));
        }
    }
}
