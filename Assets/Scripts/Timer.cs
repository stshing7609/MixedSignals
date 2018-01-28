using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
    public Text timer;
    float countdown = 60f;
    public GameObject winPanel;
    public Text winText;
    public GameObject sig1;
    public GameObject sig2;
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        timer.text = "Time: " + Mathf.Round(countdown);

        if(countdown <= 0)
        {
            DoGameOver();
        }
	}

    void DoGameOver()
    {
        string text;
        if (sig1.GetComponent<Signal>().score >= sig2.GetComponent<Signal>().score)
        {
            text = "Enjoy your date, Team 1!";
        }
        else
        {
            text = "Enjoy your date, Team 2!";
        }
        winText.text = text;
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
