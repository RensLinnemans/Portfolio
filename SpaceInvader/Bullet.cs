using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public string target;

    GameManager Contr = GameManager.instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);

        if (transform.position.y < -4)
        {
            Destroy(this.gameObject);
            Contr.RandomShoot();
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag(target))
        {
            Destroy(this.gameObject);
            Contr.RandomShoot();
        }
    }
}
