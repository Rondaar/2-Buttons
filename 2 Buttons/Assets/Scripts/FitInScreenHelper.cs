using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitInScreenHelper : MonoBehaviour {

    public static float GetDistance(Vector3 pos1, Vector3 pos2)
    {
        pos1 = Camera.main.WorldToViewportPoint(pos1);
        pos2 = Camera.main.WorldToViewportPoint(pos2);
        float width = GameMaster.instance.ScreenOffset*2 +1;
        Vector2 distVector;
        distVector.x = Mathf.Abs(pos1.x - pos2.x);
        if (distVector.x>width/2f)
        {
            distVector.x = width - distVector.x;
            
        }
        distVector.y = Mathf.Abs(pos1.y - pos2.y);
        if(distVector.y>width/2f)
        {
            distVector.y = width - distVector.y;
            
        }
        return distVector.magnitude;
    }
    public static Vector2 GetDirection(Vector3 pos1, Vector3 pos2)
    {
        pos1 = Camera.main.WorldToViewportPoint(pos1);
        pos2 = Camera.main.WorldToViewportPoint(pos2);
        float width = GameMaster.instance.ScreenOffset * 2 + 1;
        Vector2 distVector;
        distVector.x = pos1.x - pos2.x;
        if (Mathf.Abs(distVector.x) > width / 2f)
        {
            distVector.x = width - distVector.x;

        }
        distVector.y = pos1.y - pos2.y;
        if (Mathf.Abs(distVector.y) > width / 2f)
        {
            distVector.y = width - distVector.y;

        }
        return distVector;
    }
}
