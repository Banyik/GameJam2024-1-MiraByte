using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListHandler : MonoBehaviour
{
    public Button FuseBoxKey;
    public Button MetalDetector;
    public Button NightVision;
    public Button Tape;
    public Button Money;
    public Button Crowbar;
    public Button Bone;
    public Button FishingRod;

    public GameObject TickForFuseBoxKey;
    public GameObject TickForMetalDetector;
    public GameObject TickForNightVision;
    public GameObject TickForTapeAndMoney;
    public GameObject TickForCrowbar;
    public GameObject TickForBone;
    public GameObject TickForFishingRod;
    public void GotItem(ItemTypes itemType)
    {
        switch (itemType)
        {
            case ItemTypes.FishingRod:
                FishingRod.interactable = true;
                TickForFishingRod.SetActive(true);
                break;
            case ItemTypes.FuseBoxKey:
                FuseBoxKey.interactable = true;
                TickForFuseBoxKey.SetActive(true);
                break;
            case ItemTypes.Bone:
                Bone.interactable = true;
                TickForBone.SetActive(true);
                break;
            case ItemTypes.Crowbar:
                Crowbar.interactable = true;
                TickForCrowbar.SetActive(true);
                break;
            case ItemTypes.MetalDetector:
                MetalDetector.interactable = true;
                TickForMetalDetector.SetActive(true);
                break;
            case ItemTypes.MoneyAndTape:
                Money.interactable = true;
                Tape.interactable = true;
                TickForTapeAndMoney.SetActive(true);
                break;
            case ItemTypes.LockerKey:
                break;
            case ItemTypes.DeskKey:
                break;
            case ItemTypes.NightVisionGoogles:
                NightVision.interactable = true;
                TickForNightVision.SetActive(true);
                break;
            default:
                break;
        }
    }
}
