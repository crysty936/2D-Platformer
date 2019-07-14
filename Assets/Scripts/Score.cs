using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Score : MonoBehaviour {
    public float timeLeft = 120;
    public int score = 0;
    public GameObject TimeLeftUI;
    public GameObject playerScoreUI;
	// Use this for initialization
	void Start () {
        DataManagement.datamanagement.LoadData();
        TimeLeftUI = GameObject.FindGameObjectWithTag("Time_Left");
        playerScoreUI = GameObject.FindGameObjectWithTag("Score");
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if(timeLeft<0)
        {
            SceneManager.LoadScene("Prototipul1");
            
        }
        TimeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " +(int) timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + score);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="End")
        {
            CountScore();
           
        }
    }
    void CountScore()
    {
        Debug.Log("Data says total score is "+DataManagement.datamanagement.HighScore);
        score =score + (int)(timeLeft * 10);
        DataManagement.datamanagement.TotalScore += score;
        if (DataManagement.datamanagement.HighScore < score)
        {
            DataManagement.datamanagement.HighScore = score;
        }
        DataManagement.datamanagement.SaveData();
        Debug.Log("After saving, data says that total score is "+DataManagement.datamanagement.HighScore);

    }
}
