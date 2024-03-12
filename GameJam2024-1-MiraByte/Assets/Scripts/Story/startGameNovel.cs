using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGameNovel : MonoBehaviour
{
    public List<GameObject> pages;
    public int pageCount;
    public void Start()
    {
        pages[0].SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && pages.Count - 1 == pageCount)
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetMouseButtonDown(0) && pages.Count - 1 > pageCount)
        {
            pageCount++;
            pages[pageCount].SetActive(true);
            pages[pageCount - 1].SetActive(false);
        }
    }
}
