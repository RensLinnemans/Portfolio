using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoBoShooting : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bigBullet;
    public float timeLeft;
    private bool goShoot;
    public GameObject player;
    public float xShoot;
    private int bulletCount;
    private bool bovePlatform;
    public int bossHealth;

    // Start is called before the first frame update
    void Start()
    {
        bulletCount = 0;
        timeLeft = 0;
        goShoot = false;
        xShoot = 4.1f;
        player = GameObject.FindGameObjectWithTag("Player");
        bovePlatform = true;
        bossHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(bossHealth <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(sceneName: "Win");
        }
        if (player.transform.position.x > xShoot)
        {
            goShoot = true;
        }
        if (goShoot == true)
        {
            if (timeLeft < 0 && bulletCount < 6)
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
                Instantiate(bullet, pos, Quaternion.identity);
                timeLeft = 0.4f;
                bulletCount++;
            }
            else if (timeLeft < 0 && bulletCount <= 6)
            {
                timeLeft = 1.2f;
                Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
                Instantiate(bigBullet, pos, Quaternion.identity);
                bulletCount = 0;
                if (bovePlatform == false)
                {
                    bovePlatform = true;
                }
                else if(bovePlatform == true)
                {
                    bovePlatform = false;
                }
            }

            if (bulletCount <= 6 && bovePlatform == true)
            {
                transform.position = new Vector3(20.47f, 4.4f, 0);
            }
            else if (bulletCount <= 6 && bovePlatform == false)
            {
                transform.position = new Vector3(20.47f, 0.49f, 0);
            }
        }
        timeLeft -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "playBul")
        {
            bossHealth--;
        }
    }
}
