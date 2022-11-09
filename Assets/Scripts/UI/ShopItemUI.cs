using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour {
    public Item item;
    public Button button;
    public UnityEvent OnPurchaseEvents;

    void Start() { button.onClick.AddListener(OnPurchaseButtonClicked); }
    public virtual void OnPurchaseButtonClicked() {
        if (GameManager.money < item.buyPrice) return;
        GameManager.AddMoney(-item.buyPrice);
        OnPurchaseEvents.Invoke();
    }

    public void OnPurchaseHasteEffect() {
        GlobalStats.attackSpeedModifier *= 1.10f;
        GlobalStats.moveSpeedModifier *= 1.07f;
        GlobalStats.projectileSpeedModifier *= 1.05f;
    }
    public void OnPurchaseTeleportEffect() {
        GlobalStats.canTeleport = true;
        RemoveSelfFromShopList();
    }
    public void OnPurchaseBetterSightEffect() {
        GameManager.GetCamera().orthographicSize += 0.45f;
    }
    public void RemoveSelfFromShopList() {
        gameObject.SetActive(false);
    }
}