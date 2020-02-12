using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manage : MonoBehaviour
{
    public int score;
    public int health;
    public bool death = false;

    public GameObject[] food = new GameObject[6];
    public List<GameObject> foods = new List<GameObject>();

    public static Manage instance = null;
    void Awake()
    {
        if (instance == null) instance = this;
        // Start is called before the first frame update
    }
    void Start()
    {
        foodPlace(/*food.Length, 1, 1*/);
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (foods.Count == 0)
        {
            foodPlace();
        }
    }

    void foodPlace(/*int range, int luck, int badluck*/)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int ii = -5; ii < 6; ii++)
            {
                Vector3 pos = new Vector3(ii * 2f, (i + .5f) * 2f, 0);
                GameObject fuud = Instantiate(food[Random.Range(0,food.Length)], pos, Quaternion.identity) as GameObject;
                foods.Add(fuud);
            }
        }
    }
}
