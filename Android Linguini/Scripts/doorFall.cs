using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorFall : MonoBehaviour
{
    public GameObject thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        GameObject thePlayer = GameObject.Find("thePlayer");
        playerMovement playerScript = thePlayer.GetComponent<playerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.doorStuck == true)
        {
            Destroy(GetComponent<FixedJoint2D>());
        }
    }
}
