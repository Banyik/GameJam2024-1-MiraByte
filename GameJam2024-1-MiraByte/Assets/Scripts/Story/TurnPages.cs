using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPages : MonoBehaviour
{
    public List<GameObject> pages;
    public GameObject wholePage, nextPage;
    public int pageCount;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && pages.Count - 1 == pageCount)
        {
            wholePage.SetActive(false);
            nextPage.SetActive(true);
        }
        if (Input.GetMouseButtonDown(0) && pages.Count-1 > pageCount) 
        {
            pageCount++;
            pages[pageCount].SetActive(true);
        }
    }
}
