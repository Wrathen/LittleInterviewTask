using UnityEngine;

public class Coin : MonoBehaviour {
    public void OnCollect() {
        int amount = Random.Range(50, 2750);
        GameManager.AddMoney(amount);
        Destroy(gameObject);
    }
}