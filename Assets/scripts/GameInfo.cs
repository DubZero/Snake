using UnityEngine;
using System.Collections;

public class GameInfo : MonoBehaviour {

    public GameObject Info; // Неразрушаемый объект
    public static float Speed;// Скорость змеи
    public static float Size;// Размер поля (int)float от 1 до 3 
    public static int Score;// Количество очков последней игры
    public static string Name;// Имя игрока в последней игре
    void Awake()
    {
        DontDestroyOnLoad(Info); // Неразрушаемый объект для переноса информации в другую сцену
    }
    void Start()
    {
        
    }
	void Update () {
        // Скорость перемещения змейки
        if (Application.loadedLevel == 0)
        {
            // Сбор данных из меню для начала игры
            Speed = GameObject.Find("MainMenu").GetComponent<MainMenu>().Speed;
            Size  = GameObject.Find("MainMenu").GetComponent<MainMenu>().Size;
        }        
	}
}
