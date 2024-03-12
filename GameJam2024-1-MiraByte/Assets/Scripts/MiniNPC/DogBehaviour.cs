using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Player;
public class DogBehaviour : MonoBehaviour
{
    public GameObject Player;
    public float growlDistance;
    public float barkDistance;

    public SpriteRenderer spriteRenderer;
    public Sprite sit;
    public Sprite stand;

    public AudioSource source;
    public AudioClip growl;
    public AudioClip bark;
    public AudioClip eat;

    public GameObject pauseMenu;
    public GameObject listMenu;
    public GameObject gameOverMenu;


    bool hasBone = false;

    void Update()
    {
        if (hasBone)
        {
            return;
        }
        if(Vector3.Distance(gameObject.transform.position, Player.transform.position) < barkDistance)
        {
            if(Player.GetComponent<Inventory>().items.Count > 0 && Player.GetComponent<Inventory>().items.Where(x => x.item == ItemTypes.Bone).ToList().Count > 0)
            {
                spriteRenderer.sprite = sit;
                if(source.clip != eat)
                {
                    source.clip = eat;
                    source.Play();
                }
                hasBone = true;
                return;
            }
            if (source.clip != bark)
            {
                source.clip = bark;
                source.Play();
            }
            pauseMenu.SetActive(false);
            listMenu.SetActive(false);
            Time.timeScale = 0f;
            gameOverMenu.SetActive(true);
        }
        else if(Vector3.Distance(gameObject.transform.position, Player.transform.position) < growlDistance)
        {
            spriteRenderer.sprite = stand;
            if (source.clip != growl)
            {
                source.clip = growl;
                source.Play();
            }
        }
        else
        {
            spriteRenderer.sprite = sit;
            source.Stop();
        }
    }
}
