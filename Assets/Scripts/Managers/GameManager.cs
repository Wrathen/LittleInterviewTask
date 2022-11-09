using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager i;

    public static int money = 0;

    private GameObject player;
    private Camera mainCam; // Cache it, 'cause Unity doesn't

    // Base Functions
    void Awake() { i = this; }

    // Main Functions
    public static void AddMoney(int amount) {
        money += amount;
        UIManager.UpdateCoinText(money);
    }

    // Utility Functions
    public static GameObject GetPlayer() {
        if (!i.player) i.player = GameObject.Find("Player");
        return i.player;
    }
    public static Camera GetCamera() {
        if (!i.mainCam) i.mainCam = Camera.main;
        return i.mainCam;
    }
}