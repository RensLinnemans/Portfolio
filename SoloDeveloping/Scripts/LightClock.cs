using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightClock : MonoBehaviour
{
    public float count;

    // Start is called before the first frame update
    void Start()
    {
        count = 22f;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime * 10;
        /*if (count > 165)
        {
            count = 22;
        }*/
        transform.eulerAngles = new Vector3(count, 10, 0);
        //22 start good
        // 65  good good
        //160 end good
    }
}
