using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objSpin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //transform.localEulerAngles = new Vector3(0, 0, Random.Range(0, 180));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,1);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
