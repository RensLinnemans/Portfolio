using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private int speed = 1;
    public GameObject bullet;
    GameManager Contr = GameManager.instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(speed * Time.deltaTime, 0, 0);
       
        if (transform.position.y < -4)
        {
            Application.Quit();
            Application.Quit();
        }
    }
    public void Shoot()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
        Instantiate(bullet, pos, Quaternion.identity);
    }

    void Moving(int speed)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Contr.enemies.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
