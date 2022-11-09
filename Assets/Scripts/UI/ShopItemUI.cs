using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour {
    public Sprite sprite;
    public string itemName;
    public int cost;
    public Button button;
    public UnityEvent OnPurchaseEvents;

    void Start() { button.onClick.AddListener(OnPurchaseButtonClicked); }

    public virtual void OnPurchaseButtonClicked() {
        if (GameManager.money < cost) return;
        GameManager.AddMoney(-cost);
        OnPurchaseEvents.Invoke();
    }
    public void OnPurchaseMeatEffect() {
        GlobalStats.characterSizeModifier *= 1.01f;
        GameManager.GetPlayer().GetComponent<Player>().OnCharacterSizeChanged();
    }
    public void OnPurchaseHasteEffect() {
        GlobalStats.attackSpeedModifier *= 1.10f;
        GlobalStats.moveSpeedModifier *= 1.07f;
        GlobalStats.projectileSpeedModifier *= 1.05f;
    }
    public void OnPurchaseTeleportEffect() {
        GameManager.canTeleport = true;
        RemoveSelfFromShopList();
    }
    public void OnPurchaseBetterSightEffect() {
        GameManager.GetCamera().orthographicSize += 0.45f;
    }
    public void RemoveSelfFromShopList() {
        gameObject.SetActive(false);
    }
    public void AddSelfToInventory() {
        GameManager.GetPlayer().GetComponent<Inventory>().AddItem(new Item(sprite, itemName, cost));
    }
}