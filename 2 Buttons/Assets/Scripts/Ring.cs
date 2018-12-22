using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour {

    [SerializeField]
    AnimationCurve animCurve;
    [SerializeField]
    float speed;

    Material mat;
    float progress = 0;

	// Use this for initialization
	void Start () {
        mat = GetComponent<MeshRenderer>().material;
	}
	
	// Update is called once per frame
	void Update ()
    {
       
        mat.SetFloat("_RingRadius", Mathf.LerpUnclamped(0,1,animCurve.Evaluate( progress)));
        Color matColor = mat.color;
        mat.color = new Color(matColor.r, matColor.g, matColor.b, Mathf.LerpUnclamped(1, 0, animCurve.Evaluate(progress)));
        progress += Time.deltaTime * speed;
        if (progress > 1) { Destroy(gameObject); }
    }
}
