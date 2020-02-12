using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateBox : MonoBehaviour
{
    public GameObject theBox;
    public float counter;
    // Start is called before the first frame update
    void Start()
    {
        GameObject AmmoBocxxa = GameObject.Find("AmmoBocxxa");
        ammoBox ammoScript = AmmoBocxxa.GetComponent<ammoBox>();

        ammoBox.count = false;
        counter = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (ammoBox.count == true)
        {
            counter -= Time.deltaTime;
        }
        if (counter <= 0)
        {
            Instantiate(theBox, new Vector3(14.14f, 0.02f, 0), Quaternion.identity);
            ammoBox.count = false;
            counter = 10f;
        }
    }
}
