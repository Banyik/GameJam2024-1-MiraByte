using System.Collections;
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
    public int timeToDeactivateText;
    public bool hasHoverItem;
    public GameObject hoverItem;
    public ActionTypes actionType;
    public GameObject interactableGameObject;
    public bool isOnlyForGuard;
    public bool dontCheckDistance = false;
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
                CancelDeactivationInvoke();
                CheckTileTextObserver.Subscribe(gameObject);
                CheckTileTextObserver.AlertObserver(gameObject);
                text.text = message;
                text.gameObject.SetActive(true);
                Invoke(nameof(DeactivateText), timeToDeactivateText);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            switch (actionType)
            {
                case ActionTypes.DoorInteract:
                    if (isOnlyForGuard && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().playerType == PlayerType.Guard)
                    {
                        TileChanger.ChangeTile();
                    }
                    else if (isOnlyForGuard)
                    {
                        CancelDeactivationInvoke();
                        CheckTileTextObserver.Subscribe(gameObject);
                        CheckTileTextObserver.AlertObserver(gameObject);
                        text.text = "Nekem nincs ehhez hozzáférésem...";
                        text.gameObject.SetActive(true);
                        Invoke(nameof(DeactivateText), timeToDeactivateText);
                        if (!audioSource.isPlaying)
                        {
                            audioSource.clip = actionClip;
                            audioSource.Play();
                        };
                    }
                    else
                    {
                        TileChanger.ChangeTile();
                    }
                    break;
                case ActionTypes.CheckInteractableItem:
                    interactableGameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().canMove = false;
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

    void DeactivateText()
    {
        text.gameObject.SetActive(false);
        CheckTileTextObserver.UnSubscribe(gameObject);
        CheckTileTextObserver.DisableAlert();
    }
}
