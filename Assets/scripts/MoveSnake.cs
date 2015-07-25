using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class MoveSnake : MonoBehaviour {
    public float SpawnTime;   // Частота перемещения змейки
    public bool StopFlag = false;
    public GameObject tail = null;
    public bool eat;
    public int Score = 0;
    public int TransformCount = 0;// Счетчик ходов для стабилизации управления
    public List<Transform> listTail = new List<Transform>(); // Лист типа Transform для хранения позиций хвоста
    
    void Start()
    {
        SpawnTime = GameInfo.Speed; // Передача параметров из сцены меню
        InvokeRepeating("Move", 1.0f, SpawnTime); //Вызов Функции начиная с 1 сек каждые SpawnTime секунд
    }
    void Update()
    {
        Control(); // Управление поворотом змеи
        Pause();   // Проверка на паузу
    }
    void ScoreCalc(float Size, float Speed) // Подсчет очков на основе скорости и размеров поля (сложность игры) 
    {
        Score += 6/((int)Size) * (int)((1/Speed) * 100);
        GameObject.Find("ScoreText").GetComponent<ScoreManager>().score = Score;  
    }
    void Control()
    {
        // Управление змеей
        if (TransformCount == 1)
        {
            if (transform.eulerAngles.z == 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    print("Left нажато");
                    transform.Rotate(new Vector3(0, 0, 90));
                    TransformCount--;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    print("Right нажато");
                    transform.Rotate(new Vector3(0, 0, -90));
                    TransformCount--;
                }
            }
            else if (transform.eulerAngles.z == 180)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    print("Left нажато");
                    transform.Rotate(new Vector3(0, 0, -90));
                    TransformCount--;
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    print("Right нажато");
                    transform.Rotate(new Vector3(0, 0, 90));
                    TransformCount--;
                }
            }
            else if (transform.eulerAngles.z == 270)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    print("Down нажато");
                    transform.Rotate(new Vector3(0, 0, -90));
                    TransformCount--;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    print("Up нажато");
                    transform.Rotate(new Vector3(0, 0, 90));
                    TransformCount--;
                }
            }
            else if (transform.eulerAngles.z == 90.00001f)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    print("Down нажато");
                    transform.Rotate(new Vector3(0, 0, 90));
                    TransformCount--;
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    print("Up нажато");
                    transform.Rotate(new Vector3(0, 0, -90));
                    TransformCount--;
                }
            }
        }
    }
    void Growth()
    {
        // Рост змейки
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
            if (!StopFlag)
            {
                listTail.Last().position = ta;
                // Добавление в начало листа, и очистка с конца
                listTail.Insert(0, listTail.Last());
                listTail.RemoveAt(listTail.Count - 1);
            }
        }
    }
    void Move()
    {
        if (TransformCount == 1)
        {
            TransformCount = 0;
        }
        Growth();
        // Перемещение
        if (StopFlag == false)
        {
            TransformCount = 1;
            transform.Translate(Vector3.up);
            
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {

        // Столкновение с едой
        if (coll.tag == "Food")
        {
            eat = true; // Флаг для роста змеи
            ScoreCalc(GameInfo.Size, GameInfo.Speed); // Подсчет очков 
            Destroy(coll.gameObject); // Удаление объекта еды
            GetComponent<Spawn>().SpawnFood(); // Создание нового объекта
        }

        // Столкновение со стеной
        else if (coll.tag == "Wall")
        {
            StopFlag = true;
        }

        // Столкновение с хвостом
        else if (coll.tag == "Tail")
        {
            StopFlag = true;  
        }
    }
    void Pause()
    {
        if (!(GetComponent<GameOver>().GameOverFlag))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (StopFlag == true)
                {
                    StopFlag = false;
                }
                else
                {
                    StopFlag = true;
                }
            }
        }
    }
}
