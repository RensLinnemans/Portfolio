using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    private Rigidbody rb;
    public string Jump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        RaycastHit lHit;

        if (Physics.Raycast(transform.position, Vector3.left, out lHit, 0.8f) && lHit.collider.CompareTag("Wall"))
        {
            if (Input.GetAxisRaw(Jump) == 1 && Input.GetKeyDown("space"))
            {
                rb.Sleep();
                rb.AddForce(350, 350, 0);
                //rb.GetPointVelocity;
                Debug.Log("walljump");
                //StartCoroutine("reset");
            }
            Debug.Log("hit wall");
        }
        if (Physics.Raycast(transform.position, Vector3.right, out lHit, 0.8f) && lHit.collider.CompareTag("Wall"))
        {
            if (Input.GetAxisRaw(Jump) == 1 && Input.GetKeyDown("space"))
            {
                rb.Sleep();
                rb.AddForce(-350, 350, 0);
                Debug.Log("walljump");
            }
            Debug.Log("hit wall");
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            //rb.AddForce(0, 0, 0);
            rb.Sleep();
        }
    }

    //IEnumerator reset()
    //{
    //    yield return new WaitForSeconds(1);
    //    rb.AddForce(0, 0, 0);
    //    transform.position = Vector3.zero;
    //}
}
