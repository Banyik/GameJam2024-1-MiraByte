using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Inventory : MonoBehaviour
{
    public List<Items> items = new List<Items>();
    public GameObject FlowerInventory;
    public ListHandler handler;
    public void AddItem(Items item)
    {
        if(gameObject.GetComponent<PlayerBehaviour>().playerType == PlayerType.Prisoner)
        {
            handler.GotItem(item.item);
        }
        items.Add(item);
    }

    public void RemoveItem(Items item)
    {
        items.Remove(item);
    }

    public void PlaceItemsToFlower(PlayerType type)
    {
        if(type == PlayerType.Prisoner)
        {
            foreach (var item in new List<Items>(items))
            {
                if (item.neededToPlaceDownByPrisoner)
                {
                    FlowerInventory.GetComponent<Inventory>().AddItem(item);
                    RemoveItem(item);
                }
            }
            foreach (var item in new List<Items>(FlowerInventory.GetComponent<Inventory>().items))
            {
                if (item.neededToPlaceDownByGuard)
                {
                    AddItem(item);
                    FlowerInventory.GetComponent<Inventory>().RemoveItem(item);
                }
            }
        }
        else if (type == PlayerType.Guard)
        {
            foreach (var item in new List<Items>(items))
            {
                if (item.neededToPlaceDownByGuard)
                {
                    FlowerInventory.GetComponent<Inventory>().AddItem(item);
                    RemoveItem(item);
                }
            }
            foreach (var item in new List<Items>(FlowerInventory.GetComponent<Inventory>().items))
            {
                if (item.neededToPlaceDownByPrisoner)
                {
                    AddItem(item);
                    FlowerInventory.GetComponent<Inventory>().RemoveItem(item);
                }
            }
        }
    }

}
