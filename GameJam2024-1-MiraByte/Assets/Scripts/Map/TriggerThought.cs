using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Player;

public class TriggerThought : MonoBehaviour
{
    public CheckTileTextObserver CheckTileTextObserver;
    public TMP_Text text;
    public string message;
    public GameObject Player;
    public GameObject trigger;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && collision.GetComponent<PlayerBehaviour>().playerType == PlayerType.Prisoner &&
            Player.GetComponent<Inventory>().items.Where(x => x.item == ItemTypes.MoneyAndTape).ToList().Count > 0)
        {
            trigger.SetActive(true);
        }
        else if(collision.tag == "Player" && collision.GetComponent<PlayerBehaviour>().playerType == PlayerType.Prisoner)
        {
            CancelDeactivationInvoke();
            CheckTileTextObserver.Subscribe(gameObject);
            CheckTileTextObserver.AlertObserver(gameObject);
            text.text = message;
            text.gameObject.SetActive(true);
            Invoke(nameof(DeactivateText), 3);
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
