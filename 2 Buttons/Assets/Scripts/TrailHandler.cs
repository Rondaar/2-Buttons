using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailHandler : MonoBehaviour {
    Rigidbody2D playerRb;
    TrailRenderer trRndr;
    private float trailTime;

    public float TrailTime
    {
        get
        {
            return trailTime;
        }
        set
        {
            trailTime = Mathf.Min(6,value);
            trRndr.time = trailTime;
        }
    }

	void Start ()
    {
        playerRb = GetComponentInParent<Rigidbody2D>();
        trRndr = GetComponent<TrailRenderer>();
	}

    // Update is called once per frame
    public void CopyPlayerMovement()
    {
        StartCoroutine(Move());    
    }
    IEnumerator Move()
    {
        gameObject.AddComponent<Rigidbody2D>();
        Rigidbody2D myRb= gameObject.GetComponent<Rigidbody2D>();
        myRb.gravityScale = 0;
        while (true)
        {
            if (playerRb != null) {
                myRb.velocity = (playerRb.velocity.magnitude * (transform.position- Vector3.zero).normalized);
            }
            yield return null;
        }
    }

    private void OnDestroy()
    {
        if (playerRb!=null)
            playerRb.GetComponent<TrailManager>().Trails.Remove(this);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
