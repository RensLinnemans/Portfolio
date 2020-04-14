using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayedCamera : MonoBehaviour {

    public GameObject target;
    /*public float interpVelocity;
   public float minDistance;
   public float followDistance;
   public Vector3 offset;
   Vector3 targetPos;*/

    // Use this for initialization
    void Start()
    {
        //targetPos = transform.position;
        GameObject thePlayer = GameObject.Find("thePlayer");
        playerMovement playerScript = thePlayer.GetComponent<playerMovement>();
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(target.transform.position.x, 4, -10);

        /*if (playerMovement.doorStuck == true);
        {
            transform.position = new Vector3(target.transform.position.x, 4, -10);
        }*/
    }

    // Update is called once per frame
    /*void FixedUpdate()
    {
        /*if (target)

        {
            /*Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * 15f;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
        }
    }*/
}
