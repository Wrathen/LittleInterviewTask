using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopEquipmentUI : MonoBehaviour {
    public Equipment equipment;
    public Button equipButton;
    public Button buySellButton;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI buttonText;
    public TextMeshProUGUI equipButtonText;

    bool isPurchased = false;

    void Start() {
        buySellButton.onClick.AddListener(OnPurchaseButtonClicked);
        equipButton.onClick.AddListener(OnEquipButtonClicked);
    }
    public void UpdateUI() {
        nameText.text = equipment.itemName + " - " + (isPurchased ? equipment.sellPrice : equipment.buyPrice) + "g";
        buttonText.text = isPurchased ? "Sell" : "Buy";
        equipButtonText.text = equipment.isEquipped ? "Unequip" : "Equip";
    }

    public void OnPurchaseButtonClicked() {
        if (isPurchased) { OnSellButtonClicked(); return; }
        if (GameManager.money < equipment.buyPrice) return;
        
        GameManager.AddMoney(-equipment.buyPrice);
        isPurchased = true;

        if (GlobalStats.autoEquipEnabled) equipment.Equip();
        ShowEquipButton();
        UpdateUI();
    }
    public void OnSellButtonClicked() {
        GameManager.AddMoney(equipment.sellPrice);
        isPurchased = false;

        equipment.Unequip();
        HideEquipButton();
        UpdateUI();
    }
    void OnEquipButtonClicked() {
        if (equipment.isEquipped) equipment.Unequip();
        else equipment.Equip();
        UpdateUI();
    }

    public void ShowEquipButton() { equipButton.gameObject.SetActive(true); }
    public void HideEquipButton() { equipButton.gameObject.SetActive(false); }
}