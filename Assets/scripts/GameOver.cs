using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {


    public bool GameOverFlag = false;
    public string ScoreString;
	void Start () {	}
	void Update () {
        // Поражение если StopFlag = true и PauseFlag = false
        if (GetComponent<MoveSnake>().StopFlag && !(GetComponent<Esc_pause>().PauseFlag) && !GameOverFlag )
        {
            Debug.Log("GameOver!");
            GameOverFlag = true;
            ScoreString = GetComponent<MoveSnake>().Score.ToString(); // Перевод результата в String 
            GameInfo.Score = GetComponent<MoveSnake>().Score; // Запись последнего результата
        }
	}
    void OnGUI()
    {

        // Окно Game Over
        if (GameOverFlag)
        {
            GUI.Box(new Rect(50, 30, Screen.width - 100, Screen.height - 60),"Game Over!");

            GUI.Label(new Rect(Screen.width / 2 - 60, Screen.height / 2, 200, 200), "Очки: ");
            ScoreString = GUI.TextArea(new Rect(Screen.width / 2 - 20, Screen.height / 2, 80, 20), ScoreString);

            if (GUI.Button(new Rect(Screen.width / 2 - 250, Screen.height / 2 + 100, 200, 30), "Начать заново"))
            {
                Application.LoadLevel(1);
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 50, Screen.height / 2 + 100, 200, 30), "В главное меню"))
            {
                Application.LoadLevel(0);
            }
            
        }
    }

}
