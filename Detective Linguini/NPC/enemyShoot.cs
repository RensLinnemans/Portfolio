using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    public GameObject shot;
    public float timeLeft;
    private bool goShoot;
    public GameObject player;
    public float xShoot;
    public float offscreen;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 0;
        goShoot = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > xShoot)
        {
            goShoot = true;
        }
        if (player.transform.position.x < xShoot)
        {
            goShoot = false;
        }

        if (player.transform.position.x > offscreen)
        {
            Destroy(this.gameObject);
        }
        if (goShoot == true)
        {
            if (timeLeft < 0)
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
                Instantiate(shot, pos, Quaternion.identity);
                timeLeft = 0.4f;
            }
        }
        timeLeft -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "playBul")
        {
            Destroy(this.gameObject);
        }
    }
}
