using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailManager : MonoBehaviour {

    public List<TrailHandler> Trails { get; set; }
    [SerializeField]
    float trTime=0.25f;

    private void Start()
    {
        Trails = new List<TrailHandler>();
        Trails.Add(GetComponentInChildren<TrailHandler>());
        GetComponentInChildren<TrailRenderer>().time = trTime;
    }
    public void IncrementTailTime(float amount)
    {
        trTime += amount;
        foreach(TrailHandler tr in Trails)
        {
            tr.TrailTime = trTime;
        }
    }
}
