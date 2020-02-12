using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAH : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }
    public void gameStart()
    {
        StartCoroutine(Counter());
    }
    IEnumerator Counter()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName: "Game");
    }
    public void gameOver()
    {
        SceneManager.LoadScene(sceneName: "Main");
    }
    public void gameQuit()
    {
        Application.Quit();
    }
}
