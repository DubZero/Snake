using UnityEngine;
using System.Collections;

public class GameInfo : MonoBehaviour {

    public GameObject Info;
    public static float Speed;
    public static float Size;
    public static int Score;
    void Awake()
    {
        DontDestroyOnLoad(Info);
    }

    void Start()
    {
        
    }
	
	void Update () {
        // Скорость перемещения змейки
        if (Application.loadedLevel == 0)
        {
            Speed = GameObject.Find("MainMenu").GetComponent<MainMenu>().Speed;
            Size  = GameObject.Find("MainMenu").GetComponent<MainMenu>().Size;

        }
        
	}
}
