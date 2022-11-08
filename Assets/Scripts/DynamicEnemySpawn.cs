using System.Collections.Generic;
using UnityEngine;

public class DynamicEnemySpawn : MonoBehaviour {
    public GameObject[] enemyPrefabs;
    public uint enemyCount = 6;

    private static DynamicEnemySpawn instance;
    private List<Transform> spawnZones;

    // Base Functions
    void Awake() {
        instance = this;
        spawnZones = new List<Transform>();

        for (int i = 0; i < transform.childCount; ++i)
            spawnZones.Add(transform.GetChild(i));
    }
    void Start() { for (int i = 0; i < enemyCount; ++i) SpawnEnemy(); }

    // Main Functions
    public Transform GetRandomSpawnZone() { return spawnZones[Random.Range(0, spawnZones.Count)]; }
    public GameObject GetRandomEnemyPrefab() { return enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]; }
    public Vector3 GetRandomPositionWithinZone(Transform zone) {
        float halfWidth = zone.localScale.x / 20;
        float halfHeight = zone.localScale.y / 20;
        float x = Random.Range(zone.position.x - halfWidth, zone.position.x + halfWidth);
        float y = Random.Range(zone.position.y - halfHeight, zone.position.y + halfHeight);

        return new Vector3(x, y, -1);
    }
    public void SpawnEnemy() {
        if (enemyCount == 0) return;
        GameObject enemyToSpawn = GetRandomEnemyPrefab();
        Transform zone = GetRandomSpawnZone();

        Instantiate(enemyToSpawn, GetRandomPositionWithinZone(zone), Quaternion.identity);
    }

    // Events
    public static void OnEnemyDeath() { instance.SpawnEnemy(); }
}