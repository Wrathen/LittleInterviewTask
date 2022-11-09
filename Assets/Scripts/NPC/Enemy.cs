using UnityEngine;

public class Enemy : MonoBehaviour {
    public GameObject loot_coin;

    // Let's just kill them instantly.
    public void TakeDamage() {
        Instantiate(loot_coin, transform.position, Quaternion.identity);

        DynamicEnemySpawn.OnEnemyDeath(); // Notify the spawner, so we spawn more
        Destroy(gameObject);
    }
}