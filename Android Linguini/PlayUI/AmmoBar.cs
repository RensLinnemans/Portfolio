using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    public Image ammoBar;

    // Start is called before the first frame update
    void Start()
    {
        GameObject thePlayer = GameObject.Find("thePlayer");
        playerMovement playerScript = thePlayer.GetComponent<playerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        ammoBar.fillAmount = playerMovement.ammoGun / 6;
    }
}
