using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemToInventory : MonoBehaviour
{
    public Inventory inventory;

    public void Add(int type)
    {
        switch (type)
        {
            case 0:
                inventory.AddItem(new Items(ItemTypes.Crowbar, false, false));
                break;
            case 1:
                inventory.AddItem(new Items(ItemTypes.MoneyAndTape, true, false));
                break;
            case 2:
                inventory.AddItem(new Items(ItemTypes.NightVisionGoogles, false, false));
                break;
            default:
                break;
        }
    }
}
