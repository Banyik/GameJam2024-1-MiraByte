using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Novel : MonoBehaviour
{
    public List<GameObject> pages;
    public GameObject wholePage, nextPage;
    public int pageCount;
    public void Start()
    {
        pages[0].SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && pages.Count - 1 == pageCount)
        {
            wholePage.SetActive(false);
            nextPage.SetActive(true);
        }
        if (Input.GetMouseButtonDown(0) && pages.Count - 1 > pageCount)
        {
            pageCount++;
            pages[pageCount].SetActive(true);
            pages[pageCount-1].SetActive(false);
        }
    }
}
