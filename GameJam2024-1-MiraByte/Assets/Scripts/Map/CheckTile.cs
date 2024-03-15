using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Player;

public class CheckTile : MonoBehaviour
{
    public CheckTileTextObserver CheckTileTextObserver;
    public changeTile TileChanger;
    public bool playSoundOnInteraction;
    public bool playSoundOnAction;
    public AudioSource audioSource;
    public AudioClip interactionClip;
    public AudioClip actionClip;
    public bool messageOnInteract;
    public TMP_Text text;
    public string message;
    public string guardsMessage;
    public int timeToDeactivateText;
    public bool hasHoverItem;
    public GameObject hoverItem;
    public ActionTypes actionType;
    public GameObject interactableGameObject;
    public bool isOnlyForGuard;
    public bool isOnlyForPrisoner;
    public bool dontCheckDistance = false;
    [SerializeField]
    bool itemAdded = false;
    public ItemTypes itemTypeToGive;
    public bool itemForGuard;
    public bool itemForPlayer;
    public bool needItemForAction;
    public ItemTypes neededItemType;
    public string messageIfItemIsMissing;
    public bool DestroyOnPickUp;

    public string Message { get => message; set => message = value; }

    private void OnMouseOver()
    {
        if (hasHoverItem)
        {
            hoverItem.SetActive(true);
        }
        Vector3 mousePosition = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>().ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        if(Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, mousePosition) > 7.5f && !dontCheckDistance)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (playSoundOnInteraction && !audioSource.isPlaying)
            {
                audioSource.clip = interactionClip;
                audioSource.Play();
            }
            if (messageOnInteract)
            {
                if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().playerType == PlayerType.Guard)
                {
                    CallMessage(guardsMessage);
                }
                else
                {
                    CallMessage(message);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            switch (actionType)
            {
                case ActionTypes.DoorInteract:
                    if (isOnlyForGuard && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().playerType == PlayerType.Guard)
                    {
                        if (needItemForAction && GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().items.Where(x => x.item == neededItemType).ToList().Count == 0)
                        {
                            CallMessage(messageIfItemIsMissing);
                            return;
                        }
                        TileChanger.ChangeTile();
                    }
                    else if (isOnlyForGuard)
                    {
                        CallMessage("Nekem nincs ehhez hozzáférésem...");
                        if (!audioSource.isPlaying)
                        {
                            audioSource.clip = actionClip;
                            audioSource.Play();
                        };
                    }
                    else if(isOnlyForPrisoner && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().playerType == PlayerType.Guard)
                    {
                        CallMessage("Ez nem az én feladatom...");
                        if (!audioSource.isPlaying)
                        {
                            audioSource.clip = actionClip;
                            audioSource.Play();
                        };
                    }
                    else
                    {
                        if (needItemForAction && GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().items.Where(x => x.item == neededItemType).ToList().Count == 0)
                        {
                            CallMessage(messageIfItemIsMissing);
                            return;
                        }
                        TileChanger.ChangeTile();
                    }
                    break;
                case ActionTypes.CheckInteractableItem:
                    if (DestroyOnPickUp)
                    {
                        DeactivateText();
                        Destroy(gameObject);
                    }
                    if (isOnlyForPrisoner && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().playerType == PlayerType.Guard)
                    {
                        CallMessage("Ez nem az én feladatom...");
                        if (!audioSource.isPlaying && actionClip != null)
                        {
                            audioSource.clip = actionClip;
                            audioSource.Play();
                        };
                    }
                    else if(isOnlyForGuard && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().playerType != PlayerType.Guard)
                    {
                        CallMessage("Ez nem az én feladatom...");
                        if (!audioSource.isPlaying && actionClip != null)
                        {
                            audioSource.clip = actionClip;
                            audioSource.Play();
                        };
                    }
                    else
                    {
                        if (needItemForAction && GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().items.Where(x => x.item == neededItemType).ToList().Count == 0)
                        {
                            CallMessage(messageIfItemIsMissing);
                            return;
                        }
                        GameObject.Find("ScriptHandler").GetComponent<UIBehaviour>().DisableObjects();
                        interactableGameObject.SetActive(true);
                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().canMove = false;
                    }
                    break;
                case ActionTypes.PlantInventoryInteract:
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().PlaceItemsToFlower(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().playerType);
                    break;
                case ActionTypes.GetItemByAction:
                    if (isOnlyForPrisoner && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().playerType == PlayerType.Guard)
                    {
                        CallMessage("Ez nem az én feladatom...");
                        if (!audioSource.isPlaying && actionClip != null)
                        {
                            audioSource.clip = actionClip;
                            audioSource.Play();
                        };
                    }
                    else if (isOnlyForGuard && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().playerType != PlayerType.Guard)
                    {
                        CallMessage("Ez nem az én feladatom...");
                        if (!audioSource.isPlaying && actionClip != null)
                        {
                            audioSource.clip = actionClip;
                            audioSource.Play();
                        };
                    }
                    else
                    {
                        if (!itemAdded)
                        {
                            if (needItemForAction && GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().items.Where(x => x.item == neededItemType).ToList().Count == 0)
                            {
                                CallMessage(messageIfItemIsMissing);
                                return;
                            }
                            GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().AddItem(new Items(itemTypeToGive, itemForGuard, itemForPlayer));
                            itemAdded = true;
                            GameObject.Find("PickUpSound").GetComponent<AudioSource>().Play();
                            if (DestroyOnPickUp)
                            {
                                DeactivateText();
                                Destroy(gameObject);
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            if (playSoundOnAction && !audioSource.isPlaying)
            {
                audioSource.clip = actionClip;
                audioSource.Play();
            }
        }
    }

    void CallMessage(string message)
    {
        CancelDeactivationInvoke();
        CheckTileTextObserver.Subscribe(gameObject);
        CheckTileTextObserver.AlertObserver(gameObject);
        text.text = message;
        text.gameObject.SetActive(true);
        Invoke(nameof(DeactivateText), timeToDeactivateText);
    }

    private void OnMouseExit()
    {
        if (hasHoverItem)
        {
            hoverItem.SetActive(false);
        }
    }

    public bool IsInvokingText()
    {
        return IsInvoking(nameof(DeactivateText));
    }

    public void CancelDeactivationInvoke()
    {
        CancelInvoke(nameof(DeactivateText));
        CheckTileTextObserver.UnSubscribe(gameObject);
    }

    public void DeactivateText()
    {
        text.gameObject.SetActive(false);
        CheckTileTextObserver.UnSubscribe(gameObject);
        CheckTileTextObserver.DisableAlert();
    }
}
