using UnityEngine;

[System.Serializable]
public class Item {
    public Sprite sprite;
    public string itemName;
    public int buyPrice;
    public int sellPrice;

    public Item(Sprite spr, string name, int cost) {
        sprite = spr;
        itemName = name;
        buyPrice = cost;
        sellPrice = (int) (cost * 0.75f);
    }
}