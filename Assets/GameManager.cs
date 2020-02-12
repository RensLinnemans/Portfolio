using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }
    }
    


    public GameObject enemy;
    public List<GameObject> enemies = new List<GameObject>();
    private EnemyMovement script;

    void Start()
    {
        script = enemy.GetComponent<EnemyMovement>();
        int length = 5;
        Vector3 pos;
        for (int i = 0; i < length; i++)
        {
            print(i);
            pos = new Vector3(-6 + 1.5f * i, 5, 0);
            GameObject enem = Instantiate(enemy, pos, Quaternion.identity) as GameObject;
            enemies.Add(enem);
        }

        RandomShoot();
    }

    bool left = false;
    // Update is called once per frame
    void Update()
    {
        //Left right movement
        int length = enemies.Count;
        for (int i = 0; i < length; i++)
        {
            // Linkse haalt - 8 is naar recht en onder.
            if (enemies[0].transform.position.x < -8)
            {
                left = false;
                enemies[i].transform.Translate(0, -0.5f, 0);
            }
            // Linkse haalt 8 is naar links en onder.
            else if (enemies[enemies.Count - 1].transform.position.x > 8)
            {
                left = true;
                enemies[i].transform.Translate(0, -0.5f, 0);
            }

            if (left == true)
            {
                enemies[i].transform.Translate(-1 * Time.deltaTime, 0, 0);
            }
            else
            {
                enemies[i].transform.Translate(1 * Time.deltaTime, 0, 0);
            }
        }
    }
    
    public void RandomShoot()
    {
        System.Random rnd = new System.Random();
        int i = rnd.Next(0, enemies.Count);
        if (enemies.Any())
        {
            enemies[i].GetComponent<EnemyMovement>().Shoot();
        }
    }

    /* 
     * Zodra de meest rechtse enemy voorbij x=8 is, zakken alle enemies 0,5 meter naar beneden en gaan dan daarna allemaal naar links bewegen
     * En ook zodra de meest linkse enemy voorbij x= - 8 is
     */
}
