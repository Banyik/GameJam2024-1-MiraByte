using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckTile : MonoBehaviour
{
    public CheckTileTextObserver CheckTileTextObserver;
    public changeTile TileChanger;
    public bool playSound;
    public AudioSource audioSource;
    public AudioClip clip;
    public bool messageOnInteract;
    public TMP_Text text;
    public string message;
    public int timeToDeactivateText;
    public bool callDoorAction;
    private void OnMouseOver()
    {
        Vector3 mousePosition = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>().ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        if(Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, mousePosition) > 7.5f)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (playSound)
            {
                audioSource.clip = clip;
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
            if (callDoorAction)
            {
                TileChanger.ChangeTile();
            }
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
