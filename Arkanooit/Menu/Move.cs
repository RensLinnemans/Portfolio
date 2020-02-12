using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move : MonoBehaviour
{
    public int moveX;
    public int moveXBac;
    public bool sMove;

    private void Start()
    {
        if (sMove)
        {
            transform.DOMoveX(moveX, 1.4f);
        }
    }

    public void move()
    {
        
        transform.DOMoveX(moveX, 1);
    }
    public void moveBac()
    {
        transform.DOMoveX(moveXBac, 1.4f);
    }
}
