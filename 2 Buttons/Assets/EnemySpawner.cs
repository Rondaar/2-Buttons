using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner {

    [SerializeField][Range(0,1)]
    float spawnChance = 0;
    [SerializeField]
    float spawnIncr = 0.025f;

    int startLevel=15;
    int lvl = 0;

    float SpawnChance { get { return spawnChance; } set { spawnChance = Mathf.Min(value,.8f); } }

    public void CheckForSpawn()
    {
        if (lvl >= startLevel)
        {
            if (Random.Range(0f, 1f) < spawnChance)
            {
                Spawn();
            }
            SpawnChance += spawnIncr;
        }
        else
        {
            lvl++;
        }
    }

    override public void Spawn()
    {
        GameObject instance = Instantiate(prefab);
        float offset = GameMaster.instance.ScreenOffset;
        float[] yPos = { -offset, 1f + offset };
        Vector2 newPos = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(-offset, 1f + offset), yPos[Random.Range(0, 1)], 0));
        prefab.transform.position = new Vector3(newPos.x,newPos.y,0);
    }
}
