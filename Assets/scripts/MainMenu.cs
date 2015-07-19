using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public float Speed;
    public int WindowNum = 1;
	void Start () 
    {
        if (Application.loadedLevel == 0)
        {
            WindowNum = 1;        
        }
	}
	
    void OnGUI()
    {
        GUI.BeginGroup(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 200));
        if (WindowNum == 1)
        {
            if (GUI.Button(new Rect(10, 30, 180, 30), "Играть"))
            {
                WindowNum = 2;
            }
            if (GUI.Button(new Rect(10, 70, 180, 30), "Настройки"))
            {
                WindowNum = 3;
            }
            if (GUI.Button(new Rect(10, 110, 180, 30), "Выход"))
            {
                WindowNum = 4;
            }
        } 
        if (WindowNum == 2)
        {
            GUI.Label(new Rect(10, 0, 200, 40), "Выберите уровень сложности");
            if (GUI.Button(new Rect(10, 50, 180, 30), "Начать игру"))
            {
                WindowNum = 0;
                Application.LoadLevel(1);
            }
            Speed = GUI.HorizontalScrollbar(new Rect(10, 90, 180, 30), Speed,0.05f, 0.5f, 0.1f);
            
            if (GUI.Button(new Rect(10, 130, 180, 30), "Размер границ"))
            {
                
            }
            if (GUI.Button(new Rect(10, 170, 180, 30), "Назад"))
            {
                WindowNum = 1;
            }
        }

        if (WindowNum == 3)
        {
            GUI.Label(new Rect(50, 10, 180, 30), "Настройки Игры");
            if (GUI.Button(new Rect(10, 40, 180, 30), "Игра"))
            {
            }
            if (GUI.Button(new Rect(10, 80, 180, 30), "Аудио"))
            {
            }
            if (GUI.Button(new Rect(10, 120, 180, 30), "Видео"))
            {

            }
            if (GUI.Button(new Rect(10, 160, 180, 30), "Назад"))
            {
                WindowNum = 1;
            }
        }
        if (WindowNum == 4)
        {
            GUI.Label(new Rect(50, 10, 180, 30), "Вы уже выходите?");
            if (GUI.Button(new Rect(10, 40, 180, 30), "Да"))
            {
                Application.Quit();
            }
            if (GUI.Button(new Rect(10, 80, 180, 30), "Нет"))
            {
                WindowNum = 1;
            }
        }
        GUI.EndGroup();
    }
}
