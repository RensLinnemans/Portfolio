using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(new Vector3(ball.transform.position.x, transform.position.y, ball.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(ball.transform.position.x / 40, ball.transform.position.y / 40, ball.transform.position.z));
    }
}
