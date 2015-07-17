using UnityEngine;
using System.Collections;

public class Esc_pause : MonoBehaviour {


    public bool PauseFlag = false;
    public GameObject Head;
	void Start () {
	
	}
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseFlag == true)
            {
                PauseFlag = false;
            }
            else
            {
                PauseFlag = true;
            }
        }
	}
    void OnGUI()
    {
        if (PauseFlag)
        {
            
            GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 60) / 2, 200, 30), "Начать заного");
            GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 150) / 2, 200, 30), "Выход");
           
        }

    }
}
