using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTurnPages : MonoBehaviour
{
    public List<GameObject> pages;
    public int pageCount;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && pages.Count - 1 == pageCount)
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetMouseButtonDown(0) && pages.Count - 1 > pageCount)
        {
            pageCount++;
            pages[pageCount].SetActive(true);
        }
    }
}
