using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitInScreenSpace : MonoBehaviour
{
    TrailRenderer trRndr;
    TrailManager trManager;
    private void Start()
    {
        trRndr = GetComponentInChildren<TrailRenderer>();
        trManager = GetComponent<TrailManager>();
    }
    void Update ()
    {
        Vector3 tempPos = Camera.main.WorldToViewportPoint(transform.position);
        Vector3 prevTempPos = tempPos;
        //tempPos.x =Mathf.Repeat(tempPos.x<0?tempPos+GameMaster.instance.ScreenOffset,1f+GameMaster.instance.ScreenOffset);
       // tempPos.y = Mathf.Repeat(tempPos.y, 1f+GameMaster.instance.ScreenOffset);
       if (tempPos.x<-GameMaster.instance.ScreenOffset)
        {
            tempPos.x = 1f + GameMaster.instance.ScreenOffset;
        }
       else if (tempPos.x>1+GameMaster.instance.ScreenOffset)
        {
            tempPos.x = -GameMaster.instance.ScreenOffset;
        }
        if (tempPos.y < -GameMaster.instance.ScreenOffset)
        {
            tempPos.y = 1f + GameMaster.instance.ScreenOffset;
        }
        else if (tempPos.y > 1 + GameMaster.instance.ScreenOffset)
        {
            tempPos.y = -GameMaster.instance.ScreenOffset;
        }
        if (prevTempPos.x != tempPos.x || prevTempPos.y != tempPos.y)
        {
            if (trRndr)
            {
                StartCoroutine(StopEmitting());
            }
        }
        transform.position = Camera.main.ViewportToWorldPoint(tempPos);
	}
    IEnumerator StopEmitting()
    {
        GameObject newTrail = Instantiate(trRndr.gameObject,transform);
        trManager.Trails.Add(newTrail.GetComponent<TrailHandler>());
        newTrail.GetComponent<TrailRenderer>().time = trRndr.time;
        newTrail.transform.localPosition = trRndr.transform.localPosition;
        newTrail.GetComponent<TrailRenderer>().emitting = false;
        trRndr.transform.parent = null;
        trRndr.autodestruct = true;
        TrailRenderer oldTrRndr = trRndr;
        trRndr = newTrail.GetComponent<TrailRenderer>();
        yield return new WaitForEndOfFrame();
        trRndr.emitting = true;
        //Vector3[] points = new Vector3[oldTrRndr.positionCount];
        // Debug.Log(oldTrRndr.positionCount);
        // oldTrRndr.GetPositions(points);
        oldTrRndr.gameObject.GetComponent<TrailHandler>().CopyPlayerMovement();
        trRndr.AddPosition(transform.position-transform.up);
    }
}
