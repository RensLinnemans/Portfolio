using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    /*
    Controls:
    A/D = Left right
    Space = jump
    R = straight shooting
    LShift = Up shooting
    LControl = Down shooting
    */
    private float doorCount;
    public GameObject bullet;
    public GameObject bulletUp;
    public GameObject bacBullet;
    public GameObject bacBulletUp;
    public GameObject bulletDown;
    public GameObject bacBulletDown;
    private float timeLeft;
    private bool onGround;
    private Rigidbody2D rb;
    public static bool doorStuck;
    public static bool right;
    public bool shooting;
    private float jumpTime;
    public static float ammoGun;
    public Animator animator;
    public float horizontalMove;

    public Camera main;
    public Camera boss;
    float jumpCount;
    private bool movleft;
    private bool movRight;

    // Start is called before the first frame update
    void Start()
    {
        doorCount = 1.15f;
        timeLeft = 0;
        rb = GetComponent<Rigidbody2D>();
        onGround = false;
        Vector3 theScale = transform.localScale;
        doorStuck = false;
        right = true;
        shooting = false;
        main.enabled = true;
        boss.enabled = false;
        jumpTime = 0.1f;
        ammoGun = 6;
        jumpCount = 0.2f;
    }

    private void FixedUpdate()
    {
        if (doorStuck == false && shooting == false)
        {
            if (movleft == true)
            {
                transform.Translate(-5f * Time.deltaTime, 0, 0);
            }
            else if (movRight == true)
            {
                transform.Translate(5f * Time.deltaTime, 0, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        jumpCount -= Time.deltaTime;
        if (jumpCount <= 0)
        {
            animator.SetBool("Jumping", false);
        }


        horizontalMove = Input.GetAxis("Horizontal");
        //Mathf.Abs makes the float always positive
        if (jumpCount <= 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }

        jumpTime -= Time.deltaTime;
        //Time set to wait before walking after shot
        if (timeLeft > 0.2)
        {
            shooting = true;

        }
        if (timeLeft < 0.2)
        {
            shooting = false;
        }

        //If door is falling or you have shot no walking.
        if (Input.GetKey(KeyCode.A))
        {
            movleft = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movRight = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            movRight = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            movleft = false;
        }
        if (doorStuck == false && shooting == false)
        {
            //Jumping if onGround is true AKA if colliding with a tagged object Ground
            if (onGround == true && jumpTime <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.AddForce(new Vector2(0, 375));
                    jumpTime = 0.6f;
                    jumpCount = 0.23f;
                    animator.SetBool("Jumping", true);
                    
                }
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                if (right == true)
                {
                    Vector3 theScale = transform.localScale;
                    theScale.x *= -1;
                    transform.localScale = theScale;
                }
                right = false;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (right == false)
                {
                    Vector3 theScale = transform.localScale;
                    theScale.x *= -1;
                    transform.localScale = theScale;
                }
                right = true;
            }
        }

        //Makes doorStuck false so that you only need to wait a few seconds
        if (doorStuck == true)
        {
            doorCount -= Time.deltaTime;
            if (doorCount < 0)
            {
                doorStuck = false;
                //camera switching
                main.enabled = false;
                boss.enabled = true;
            }
        }


        //Shoot straight
        if (Input.GetKey(KeyCode.R) && ammoGun > 0)
        {
            if (right == true)
            {
                if (timeLeft < 0)
                {
                    Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
                    Instantiate(bullet, pos, Quaternion.identity);
                    timeLeft = 0.4f;
                    ammoGun--;
                    animator.SetBool("Straight", true);
                    StartCoroutine(SetFalse());
                }
            }
            if (right == false)
            {
                if (timeLeft < 0)
                {
                    Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
                    Instantiate(bacBullet, pos, Quaternion.identity);
                    timeLeft = 0.4f;
                    ammoGun--;
                    animator.SetBool("Straight", true);
                    StartCoroutine(SetFalse());
                }
            }
        }

        //Shoot up
        if (Input.GetKey(KeyCode.LeftShift) && ammoGun > 0)
        {
            if (right == true)
            {
                if (timeLeft < 0)
                {
                    Vector3 pos = new Vector3(transform.position.x, transform.position.y, 30);
                    Instantiate(bulletUp, pos, Quaternion.identity);
                    timeLeft = 0.5f;
                    ammoGun--;
                    animator.SetBool("Up", true);
                    StartCoroutine(SetFalse());
                }
            }
            if (right == false)
            {
                if (timeLeft < 0)
                {
                    Vector3 pos = new Vector3(transform.position.x, transform.position.y, 30);
                    Instantiate(bacBulletUp, pos, Quaternion.identity);
                    timeLeft = 0.5f;
                    ammoGun--;
                    animator.SetBool("Up", true);
                    StartCoroutine(SetFalse());
                }
            }
        }


        //Shoot down
        if (Input.GetKey(KeyCode.LeftControl) && ammoGun > 0)
        {
            if (right == true)
            {
                if (timeLeft < 0)
                {
                    Vector3 pos = new Vector3(transform.position.x, transform.position.y, 30);
                    Instantiate(bulletDown, pos, Quaternion.identity);
                    timeLeft = 0.5f;
                    ammoGun--;
                    animator.SetBool("Down", true);
                    StartCoroutine(SetFalse());
                }
            }
            if (right == false)
            {
                if (timeLeft < 0)
                {
                    Vector3 pos = new Vector3(transform.position.x, transform.position.y, 30);
                    Instantiate(bacBulletDown, pos, Quaternion.identity);
                    timeLeft = 0.5f;
                    ammoGun--;
                    animator.SetBool("Down", true);
                    StartCoroutine(SetFalse());
                }
            }
        }

        //Counting down so you may not shoot 10000 bullets at once
        timeLeft -= Time.deltaTime;
    }

    //Check if you are colliding with Ground
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }
    private void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }

    //Check triggers
    private void OnTriggerEnter2D(Collider2D coll)
    {
        //If you collide with the invisable trigger to let the door drop
        if (coll.gameObject.tag == "Hodor")
        {
            doorStuck = true;
        }
        //Set ammo back to 6 when you pick up the box
        if (coll.gameObject.tag == "ammoBox")
        {
            ammoGun = 6;
        }
    }
    IEnumerator SetFalse()
    {
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Up", false);
        animator.SetBool("Straight", false);
        animator.SetBool("Down", false);
    }
}
