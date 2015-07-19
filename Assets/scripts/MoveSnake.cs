using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class MoveSnake : MonoBehaviour {
    
    public float SpawnTime = 0.5f;   // частота перемещения змейки]
    public bool StopFlag = false;
    public GameObject tail = null;
    public bool eat;

    List<Transform> listTail = new List<Transform>(); // Лист типа Transform для позиций хвоста
    
    void Start()
    {
        InvokeRepeating("Move", SpawnTime, SpawnTime);
    }

    
    void Update()
    {
        
    }
    void Move()
    {
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
    void OnTriggerEnter2D(Collider2D coll)
    {

        // Столкновение с едой
        if (coll.tag == "Food")
        {
            eat = true;
            Destroy(coll.gameObject);
            GetComponent<Spawn>().SpawnFood();
        }

        // Столкновение со стеной
        else if (coll.tag == "Wall")
        {
            print("Game Over!");
            StopFlag = true;
            Application.LoadLevel(0);

        }

        // Столкновение с хвостом
        else if (coll.tag == "Tail")
        {
            print("Game Over!");
            StopFlag = true;
            Application.LoadLevel(0);
        }
    }
}
