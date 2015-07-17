using UnityEngine;
using System.Collections;

public class EatSnake : MonoBehaviour {
    public float SpawnTime = 0.5f;   // частота перемещения змейки
	// Use this for initialization
	void Start () {
        Invoke("MoveSnake", SpawnTime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void MoveSnake()
    {
        Invoke("MoveSnake", SpawnTime);

        // Управление змеей
        if (transform.eulerAngles.z == 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                print("Left нажато");
                transform.Rotate(new Vector3(0, 0, 90));
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                print("Right нажато");
                transform.Rotate(new Vector3(0, 0, -90));
            }
        }
        else if (transform.eulerAngles.z == 180)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                print("Left нажато");
                transform.Rotate(new Vector3(0, 0, -90));
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                print("Right нажато");
                transform.Rotate(new Vector3(0, 0, 90));
            }
        }
        else if (transform.eulerAngles.z == 270)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                print("Down нажато");
                transform.Rotate(new Vector3(0, 0, -90));
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                print("Up нажато");
                transform.Rotate(new Vector3(0, 0, 90));
            }
        }
        else if (transform.eulerAngles.z == 90.00001f)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                print("Down нажато");
                transform.Rotate(new Vector3(0, 0, 90));
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                print("Up нажато");
                transform.Rotate(new Vector3(0, 0, -90));
            }
        }

        //=========================
        // Рост змейки
        //=========================
        Vector2 ta = transform.position;

        // Если True то увеличение размера на 1
        if (eat)
        {
            // Загрузка префаба хвоста
            tail = Instantiate(Resources.Load("Tail"), ta, Quaternion.identity) as GameObject;
            // Сохранение пути в лист 
            listTail.Insert(0, tail.transform);

            // Обнуление флага
            eat = false;
        }
        // Есть ли объекти хвоста?
        else if (listTail.Count > 0)
        {
            // Перемещение элемента хвоста на последнюю позицию где была голова 
            listTail.Last().position = ta;

            // Добавление в начало листа, и очистка с конца
            listTail.Insert(0, listTail.Last());
            listTail.RemoveAt(listTail.Count - 1);
        }

        // Перемещение на transform.up;
        if (StopFlag == false)
        {
            transform.position += transform.up;
        }
    }
}
