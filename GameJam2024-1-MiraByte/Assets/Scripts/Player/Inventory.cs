using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemTypes> items = new List<ItemTypes>();
    public int maxSize;
    public GameObject FlowerInventory;
    public void AddItem(ItemTypes item)
    {
        if(items.Count < maxSize)
        {
            items.Add(item);
        }
    }

    public void RemoveItem(ItemTypes item)
    {
        items.Remove(item);
    }

    public void AddItemToOtherInventory(ItemTypes item)
    {
        FlowerInventory.GetComponent<Inventory>().AddItem(item);
        RemoveItem(item);
    }
}
