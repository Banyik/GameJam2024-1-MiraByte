using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items
{
    public ItemTypes item;
    public bool neededToPlaceDownByPrisoner;
    public bool neededToPlaceDownByGuard;

    public Items(ItemTypes item, bool neededToPlaceDownByPrisoner, bool neededToPlaceDownByGuard)
    {
        this.item = item;
        this.neededToPlaceDownByPrisoner = neededToPlaceDownByPrisoner;
        this.neededToPlaceDownByGuard = neededToPlaceDownByGuard;
    }
}
