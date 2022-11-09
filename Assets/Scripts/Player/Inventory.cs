using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public List<Item> ownedItems;
    public List<Equipment> ownedEquipments;

    void Start() {
        ownedItems = new List<Item>();
        ownedEquipments = new List<Equipment>();
    }

    public void AddItem(Item item) { ownedItems.Add(item); }
    public void AddEquipment(Equipment equipment) { ownedEquipments.Add(equipment); }
}