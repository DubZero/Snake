using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class Snake : MonoBehaviour
{
    public GameObject food = null; // объект еда
    public GameObject tail = null;// объект хвост
    public GameObject LeftWall = null;// объект Левая граница
    public GameObject UpWall = null;// объект Верхняя граница
    public GameObject RightWall = null;// объект Правая граница
    public GameObject DownWall = null;// объект Нижняя граница
    public float SpawnTime = 0.5f;   // частота перемещения змейки
    bool eat = false; // флаг поедания еды
    bool StopFlag = false; // флаг для остановки игры при проигрыше

    List<Transform> listTail = new List<Transform>(); // Лист типа Transform для позиций хвоста


    // Создание стен и создание еды
    void Start()
    {
        SpawnWalls();
        Invoke("MoveSnake", SpawnTime);
        SpawnFood();
    }
    // Проверка на наличие еды в точке контроллера змейки
    void Update()
    {
        eatFood();
        
        if (StopFlag == false)
        {
            GameOver();
        }
    }
    // Управление змейкой
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
    // Генерация еды
    void SpawnFood()
    {
        // Генерация еды в пределах координат X и Y стен
            int x = (int)Random.Range(LeftWall.transform.position.x, RightWall.transform.position.x);
            int y = (int)Random.Range(DownWall.transform.position.y, UpWall.transform.position.y);
            food = Instantiate(Resources.Load("Food"), new Vector2(x, y), Quaternion.identity) as GameObject;
    }
    // Генерация стен
    void SpawnWalls()
    {
        LeftWall = Instantiate(Resources.Load("LeftWall"), new Vector2(-10, 0), Quaternion.identity) as GameObject;
        RightWall = Instantiate(Resources.Load("RightWall"), new Vector2(10, 0), Quaternion.identity) as GameObject;
        UpWall = Instantiate(Resources.Load("UpWall"), new Vector2(0, 5), Quaternion.identity) as GameObject;
        DownWall = Instantiate(Resources.Load("DownWall"), new Vector2(0, -5), Quaternion.identity) as GameObject;
    }
    // Функция уничтожения объектов Food при прикосновении змейки
    void eatFood()
    {
        // 0.01 погрешность возникающая при перемешения из за типа float
		if (((food.transform.position.x <= transform.position.x + 0.01)&& 
             (food.transform.position.x >= transform.position.x - 0.01))
              &&  
            ((food.transform.position.y <= transform.position.y + 0.01)&&
             (food.transform.position.y >= transform.position.y - 0.01)))
        {
			eat = true;
            Destroy(food);
			SpawnFood();
	    }

    }
    

    // проверка на столкновение стеной (и с телом змеи - не описано)
    // 0.01 возможная погрешность при перемещении
    void GameOver()
    {
        if (transform.position.x - 0.01 <= LeftWall.transform.position.x ||
            transform.position.x + 0.01 >= RightWall.transform.position.x ||
            transform.position.y + 0.01 >= UpWall.transform.position.y ||
            transform.position.y - 0.01 <= DownWall.transform.position.y)
        {
            print("Game Over!");
            StopFlag = true;
        }
    }
   
 }

    
