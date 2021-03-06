﻿using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapController : MonoBehaviour
{
    public Vector2 mapSize = new Vector2(32, 16);
    public Count itemCount = new Count(1, 4);
    public Count enemiesCount = new Count(6, 10);
    public GameObject[] enemyPrefabs;
    public GameObject[] itemPrefabs;

    [HideInInspector]
    public bool isBoss = false;
    [HideInInspector]
    public bool isKey = false;

    private List<Vector2> availablePositions = new List<Vector2>();

    private void Awake()
    {
        if (this.mapSize.x == 0 || this.mapSize.y == 0) {
            Debug.LogError("The map does not have a size.");
        }
    }

    public void SetupMap()
    {
        Spawner[] enemySpawners = GetComponentsInChildren<EnemySpawner>();
        Spawner[] itemSpawners = GetComponentsInChildren<ItemSpawner>();
        Spawner[] keySpawner = GetComponentsInChildren<KeySpawner>();

        this.CallSpawner(enemySpawners, this.enemiesCount);
        this.CallSpawner(itemSpawners, this.itemCount);

        this.CallSpawner(keySpawner, new Count(1, 1));
    }

    protected void CallSpawner(Spawner[] spawners, Count nbToSpawn)
    {
        if (spawners.Length == 0) return;

        for (int i = 0; i < nbToSpawn.GetRandomValue(); i++)
        {
            int randomIndex = Random.Range(0, spawners.Length);
            Spawner spawner = spawners[randomIndex];

            spawner.Spawn(this);
        }
    }

}
