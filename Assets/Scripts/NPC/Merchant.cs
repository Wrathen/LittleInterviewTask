using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour {
    public GameObject nearbyPanel;
    public GameObject shopPanel;
    bool playerIsNearby = false;
    bool isShopOpen = false;

    // Base Functions
    void Update() {
        if (playerIsNearby && !isShopOpen && Input.GetKeyDown(KeyCode.E))
            ShowShopUI();
    }

    // Main Functions
    public void ShowNearbyUI() { nearbyPanel.SetActive(true); }
    public void HideNearbyUI() { nearbyPanel.SetActive(false); }
    public void ShowShopUI() {
        HideNearbyUI();
        isShopOpen = true;
        shopPanel.SetActive(true);
        PlayerMovement.SetActive(false);
    }
    public void HideShopUI() {
        ShowNearbyUI();
        isShopOpen = false;
        shopPanel.SetActive(false);
        PlayerMovement.SetActive(true);
    }

    // Events
    public void OnPlayerNearby() { playerIsNearby = true; ShowNearbyUI(); }
    public void OnPlayerLeave() { playerIsNearby = false; HideNearbyUI(); }
}