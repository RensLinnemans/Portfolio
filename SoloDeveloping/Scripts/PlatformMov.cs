using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMov : MonoBehaviour
{
    public float speed;
    public float turn1;
    public float turn2;
    public string dir;

    Vector3 startPoint;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.localRotation = Quaternion.Euler(0.0, 45.0, 0.0);
        if (dir == "x")
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            if(transform.position.x < turn1)
            {
                speed = -speed;
            }
            else if (transform.position.x > turn2)
            {
                speed = -speed;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}
