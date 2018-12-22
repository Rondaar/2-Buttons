using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : Spawner
{
    [SerializeField]
    GameObject invinciblePrefab;
    [SerializeField]
    [Range(0, 1)]
    float invincibleChance = .15f;

    EnemySpawner enemySpawner;

    private void Awake()
    {
        enemySpawner = GetComponent<EnemySpawner>();
    }

    public override void Spawn()
    {
        Vector3 pos;
        pos.z = 0;
        pos.x = Random.Range(0f, 1f);
        pos.y = Random.Range(0f, 1f);
        GameObject instance;
        if (FindObjectsOfType<Asteroid>().Length>2 && Random.Range(0f,1f)<invincibleChance)
        {
            instance = Instantiate(invinciblePrefab);
        }
        else
        {
            instance = Instantiate(prefab);
        }
        instance.transform.position = Camera.main.ViewportToWorldPoint(pos);
        instance.transform.position = new Vector3(instance.transform.position.x, instance.transform.position.y, 0);
        instance.GetComponent<Collectible>().MySpawner = this;
        enemySpawner.CheckForSpawn();
    }
}
