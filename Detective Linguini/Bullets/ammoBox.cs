using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoBox : MonoBehaviour
{
    public static bool count;
    public float counter;
    Collider m_ObjectCollider;
    public Animator animator;
    public float Couning;
    public bool Counting;

    // Start is called before the first frame update
    void Start()
    {
        Couning = 0f;
        Counting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Counting == true)
        {
            Couning = 0.9f;
            Couning -= Time.deltaTime;
            animator.SetFloat("Counnt", Couning);
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        //Set ammo back to 6 when you pick up the box
        if (coll.gameObject.tag == "Player")
        {
            count = true;
            Destroy(this.gameObject, 1f);
            Counting = true;
            m_ObjectCollider = GetComponent<Collider>();
            m_ObjectCollider.isTrigger = false;
        }
    }
}
