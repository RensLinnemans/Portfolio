using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject bullet;
    private float count;
    public int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        count = 1;
    }

    // Update is called once per frame
    void Update()
    {
        count -= Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(1 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.Space) && count < 0)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
            Instantiate(bullet, pos, Quaternion.identity);
            count = 1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            health--;
            if (health == 0)
            {
                Application.Quit();
                Debug.Log("died");
            }
        }
    }
}
