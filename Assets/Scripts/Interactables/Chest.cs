using UnityEngine;

public class Chest : MonoBehaviour {
    public GameObject nearbyPanel;
    public GameObject coinPrefab;
    bool playerIsNearby = false;

    // Base Functions
    void Update() {
        if (playerIsNearby && Input.GetKeyDown(KeyCode.E))
            OpenChest();
    }

    // Main Functions
    public void ShowNearbyUI() { playerIsNearby = true; nearbyPanel.SetActive(true); }
    public void HideNearbyUI() { nearbyPanel.SetActive(false); }
    public void OpenChest() {
        Instantiate(coinPrefab, transform.position + Vector3.up, Quaternion.identity);
        Instantiate(coinPrefab, transform.position + Vector3.right, Quaternion.identity);
        Instantiate(coinPrefab, transform.position - Vector3.right, Quaternion.identity);
        Destroy(gameObject);
    }
}