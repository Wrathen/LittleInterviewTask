using UnityEngine;

public class ShopEquipmentUI : ShopItemUI {
    public EquipmentType equipmentType;
    public GameObject equipmentPrefab;

    public override void OnPurchaseButtonClicked() {
        base.OnPurchaseButtonClicked();

        Equipment eq = new Equipment(sprite, itemName, cost, equipmentType, equipmentPrefab);
        GameObject player = GameManager.GetPlayer();
        Inventory inv = player.GetComponent<Inventory>();

        inv.AddEquipment(eq);
        if (GlobalStats.autoEquipEnabled) eq.Equip();
        RemoveSelfFromShopList();
    }
}