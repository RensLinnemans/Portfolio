using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    private Vector3 step;
    public int score;
    public GameObject block;
    public GameObject canvas;
    public Text scoreText;
    public Text scoreBackground;
    public float x;
    public float y;

    // Start is called before the first frame update
    void Start()
    {
        step = new Vector3(4, -5, 0);
        step *= 0.1f;
        StartCoroutine(upStep(2));
    }

    void FixedUpdate()
    {
        x = step.x;
        y = step.y;
        transform.position = transform.position + step * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        step = Vector3.Reflect(step, collision.GetContact(0).normal);
        if (collision.gameObject.CompareTag("Food"))
        {
            Destroy(collision.transform.parent.gameObject);
            Manage.instance.foods.Remove(collision.transform.parent.gameObject);
            if (Manage.instance.score > 99) { step *= 1.01f; }
            Manage.instance.score++;
            scoreText.text = "Score: " + Manage.instance.score;
            scoreBackground.text = "Score: " + Manage.instance.score;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hurt"))
        {
            Manage.instance.health--;
            transform.localPosition = new Vector3(block.transform.position.x, -0.5f, 0);
            step *= 0.1f;
            StartCoroutine(upStep(1));
        }
    }
    IEnumerator upStep(int time)
    {
        Debug.Log(step);
        yield return new WaitForSeconds(time);
        step *= 10f;
        Debug.Log(step);
    }
}

