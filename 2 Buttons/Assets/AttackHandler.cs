using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour {
    [SerializeField]
    GameObject misslePrefab;

    PlayerInput input;
    bool canAttack = true;
	// Use this for initialization
	void Awake ()
    {
        input = GetComponent<PlayerInput>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (input.Left==0 && input.Right== 0)
        {
            if (canAttack)
            {
                Attack();
                canAttack = false;
            }
        }
        else
        {
            canAttack = true;
        }
	}

    void Attack()
    {
        GameObject instance = Instantiate(misslePrefab);
        instance.transform.position = transform.position + transform.up/4;
        instance.transform.rotation = transform.rotation;
        instance.GetComponent<Missle>().MySpawner = gameObject;
        instance.GetComponent<Missle>().Shoot();
    }
}
