using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootEnemy : MonoBehaviour
{
    public GameObject thePlayer;
    public bool shootRight;

    public float X;
    public float Y;
    public float Z;

    // Start is called before the first frame update
    void Start()
    { 
        transform.localEulerAngles = new Vector3(0, 0, Z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(X * Time.deltaTime, Y * Time.deltaTime, 0);
    }



    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
