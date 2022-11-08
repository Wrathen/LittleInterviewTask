using UnityEngine;

public class GameManager : MonoBehaviour {
    private static GameManager i;
    private GameObject player;
    private Camera mainCam; // Cache it, 'cause Unity doesn't

    void Awake() { i = this; }
    public static GameObject GetPlayer() {
        if (!i.player) i.player = GameObject.Find("Player");
        return i.player;
    }
    public static Camera GetCamera() {
        if (!i.mainCam) i.mainCam = Camera.main;
        return i.mainCam;
    }
}