using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIScore : MonoBehaviour
{
    private int count = 0;
    private int highScore;
    public GameObject totScoreObj;
    public Text totScoreTXT;
    public GameObject mainmenu;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        Manage.instance.death = false;
        mainmenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Manage.instance.death == true && count == 0)
        {
            transform.DOMoveY(2650, 4);
            totScoreObj.transform.DOMoveY(1000, 4);
            count++;
            highScore = Manage.instance.score;
            totScoreTXT.text = highScore.ToString();
            StartCoroutine(Exit());
        }
    }
    IEnumerator Exit()
    {
        yield return new WaitForSeconds(4);
        mainmenu.SetActive(true);
    }
}
