using UnityEngine;
using System.Collections;

public class Snake : MonoBehaviour
{
    public GameObject food = null;
    public GameObject LeftWall = null;
    public GameObject UpWall = null;
    public GameObject RightWall = null;
    public GameObject DownWall = null;
    public float SpawnTime = 0.5f;   
    bool eat = false;
  
  

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
    }
    // Управление змейкой
    void MoveSnake()
    {
        Invoke("MoveSnake", SpawnTime);
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
        transform.position += transform.up;
    }
    // Генерация еды
    void SpawnFood()
    {
            int x = (int)Random.Range(LeftWall.transform.position.x, RightWall.transform.position.x);
            int y = (int)Random.Range(DownWall.transform.position.y, UpWall.transform.position.y);
            food = Instantiate(Resources.Load("Food"), new Vector2(x, y), Quaternion.identity) as GameObject;
    }
    // Генерация стен
    void SpawnWalls()
    {
        LeftWall = Instantiate(Resources.Load("LeftWall"), new Vector2(10, 0), Quaternion.identity) as GameObject;
        RightWall = Instantiate(Resources.Load("RightWall"), new Vector2(-10, 0), Quaternion.identity) as GameObject;
        UpWall = Instantiate(Resources.Load("UpWall"), new Vector2(0, 5), Quaternion.identity) as GameObject;
        DownWall = Instantiate(Resources.Load("DownWall"), new Vector2(0, -5), Quaternion.identity) as GameObject;
    }
    // Функция уничтожения объектов Food при прикосновении змейки
    void eatFood()
    {
		if (((food.transform.position.x <= transform.position.x + 0.1)&& 
             (food.transform.position.x >= transform.position.x - 0.1))
              &&  
            ((food.transform.position.y <= transform.position.y + 0.1)&&
             (food.transform.position.y >= transform.position.y - 0.1)))
        {
			eat = true;
            Destroy(food);
			SpawnFood();
	    }
    }
 }

    
