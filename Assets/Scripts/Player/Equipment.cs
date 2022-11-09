using UnityEngine;

public enum EquipmentType {
    Helmet = 1,
    Gloves = 2,
    Pants = 3,
    Shoes = 4
}

[System.Serializable]
public class Equipment : Item {
    public EquipmentType equipmentType;
    public GameObject equipmentPrefab;
    public bool isEquipped = false;

    private GameObject instantiatedEquipment;

    // Constructor
    public Equipment(Sprite spr, string name, int cost, EquipmentType type, GameObject prefab):
        base(spr, name, cost) {
            equipmentType = type;
            equipmentPrefab = prefab;
        }

    // Main Functions
    public void Equip() {
        if (isEquipped) return;

        instantiatedEquipment = GameObject.Instantiate(equipmentPrefab, Vector3.zero, Quaternion.identity, GameManager.GetPlayer().transform.Find("Equipment"));
        instantiatedEquipment.name = equipmentType.ToString();
        instantiatedEquipment.transform.localPosition = equipmentPrefab.transform.position;

        isEquipped = true;
        ResetPlayerAnimator();
    }
    public void Unequip() {
        if (!isEquipped) return;

        GameObject.Destroy(instantiatedEquipment);
        isEquipped = false;
        ResetPlayerAnimator();
    }
    public void ResetPlayerAnimator() {
        GameManager.GetPlayer().GetComponent<Animator>().Rebind();
    }
}