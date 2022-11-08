using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {
    public static UIManager instance;
    public TextMeshProUGUI coinText;

    void Awake() { instance = this; }

    public static void UpdateCoinText(int amount) {
        instance.coinText.text = amount.ToString();
    }
}