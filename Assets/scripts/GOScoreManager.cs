using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GOScoreManager : MonoBehaviour {


    Text text;
    public int score;
    public GameObject GOScoreText;
    void Awake()
    {
        text = GetComponent<Text>();
        score = 0;
        GOScoreText.SetActive(false);
    }
	
	
	void Update () {
        
        if (GameObject.Find("Head").GetComponent<GameOver>().GameOverFlag)
        {
            score = GameObject.Find("ScoreText").GetComponent<ScoreManager>().score;
            text.text = "Score: " + score;
            GOScoreText.SetActive(true);
        }
	}
}
