using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour {


    Text text;
    public int score;
    void Awake()
    { 
        text = GetComponent<Text>();
        score = 0;
    }
     void Update()
    {
        // Обновление счетчика очков
        text.text = "Score: " + score;
    }
}
