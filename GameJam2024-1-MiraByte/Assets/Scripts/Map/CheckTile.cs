using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckTile : MonoBehaviour
{
    public CheckTileTextObserver CheckTileTextObserver;
    public bool playSound;
    public AudioSource audioSource;
    public AudioClip clip;
    public bool messageOnInteract;
    public TMP_Text text;
    public string message;
    public int timeToDeactivateText;
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //interact
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
        else if (Input.GetMouseButtonDown(1))
        {
            //action
            Debug.Log("Action");
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
