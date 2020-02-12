using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSideways : MonoBehaviour
{
    public KeyCode left;
    public KeyCode right;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw(axisName: "Horizontal") == -1 && transform.position.x > -11.3) { transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, -7.5f, 0); }
        if (Input.GetAxisRaw(axisName: "Horizontal") == 1 && transform.position.x < 11.3) { transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, -7.5f  , 0); }
        if (transform.position.x > 14){ transform.position = new Vector3(-14, -7.5f, 0); }
        if (transform.position.x < -14){ transform.position = new Vector3(14, -7.5f, 0); }
        if (Manage.instance.score > 100) { speed = 5 + Manage.instance.score / 10; }

    }
}
