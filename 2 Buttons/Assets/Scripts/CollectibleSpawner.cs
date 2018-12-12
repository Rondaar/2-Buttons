using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : Spawner
{
    public override void Spawn()
    {
        Vector3 pos;
        pos.z = 0;
        pos.x = Random.Range(0f, 1f);
        pos.y = Random.Range(0f, 1f);
        GameObject instance = Instantiate(prefab);
        instance.transform.position = Camera.main.ViewportToWorldPoint(pos);
        instance.transform.position = new Vector3(instance.transform.position.x, instance.transform.position.y, 0);
        instance.GetComponent<Collectible>().MySpawner = this;
    }
}
