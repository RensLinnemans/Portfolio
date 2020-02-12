using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hearts : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public int healthPlayer;


    // Update is called once per frame
    void Update()
    {
        healthPlayer = Manage.instance.health;
        health = healthPlayer;

        if (healthPlayer <= 0)
        {
            Manage.instance.death = true;
        }



        for (int i = 0; i < hearts.Length; i++)
        {
            if(health > numOfHearts)
            {
                health = numOfHearts;
            }

            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        //Go to other scene because you died
        if (coll.gameObject.tag == "Respawn")
        {
            healthPlayer--;
        }
        if (coll.gameObject.tag == "Respawn2")
        {
            healthPlayer -= 2;
        }
        if (coll.gameObject.tag == "ammoBox")
        {
                healthPlayer += 2;
        }
    }
}
