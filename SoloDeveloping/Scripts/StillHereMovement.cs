using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillHereMovement : MonoBehaviour
{
    private Rigidbody rb;
    private CharacterController cc;
    Vector3 move;
    private bool onGround;
    private bool onWall;

    public string Hori;
    public string Vert;
    public string Jump;

    float horSpeed;
    float verSpeed;
    float jumpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        transform.Translate(horSpeed * 8 * Time.deltaTime, 0, verSpeed * 8 * Time.deltaTime);
        if (onGround == true || onGround == true && onWall == true)
        {
            //jumpSpeed = Vector3.Reflect(move, collision.GetContact(0).normal);
            rb.AddForce(0, jumpSpeed * 200, 0);
        }
        else if (onWall == true)
        {
            //rb.AddForce(0, jumpSpeed * 200, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);

        horSpeed = Input.GetAxisRaw(Hori);
        verSpeed = Input.GetAxisRaw(Vert);
        jumpSpeed = Input.GetAxisRaw(Jump);
        if (Input.GetKey(KeyCode.LeftControl))
        {
            horSpeed *= 2;
            verSpeed *= 2;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            onWall = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            onWall = false;
        }
    }
}
