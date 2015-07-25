using UnityEngine;
using System.Collections;
using System.Linq;
public class Spawn : MonoBehaviour {
    public GameObject food; // объект еда
    public GameObject LeftWall;// объект Левая граница
    public GameObject UpWall;// объект Верхняя граница
    public GameObject RightWall;// объект Правая граница
    public GameObject DownWall;// объект Нижняя граница
    public float Size; // Размер границ 
    public GameObject PtLight;
	void Start () {    
        Size = GameInfo.Size;
	    SpawnWalls();
        SpawnFood();
	}
    void Update() { }
    public void SpawnFood()
    {
        // Генерация еды в пределах координат X и Y стен
        int x = (int)Random.Range(LeftWall.transform.position.x, RightWall.transform.position.x);
        int y = (int)Random.Range(DownWall.transform.position.y, UpWall.transform.position.y);
        food = Instantiate(Resources.Load("Food"), new Vector2(x, y), Quaternion.identity) as GameObject;
   
        
        while (true)
        {
            bool intersects = false;
            foreach(Transform Pos in GetComponent<MoveSnake>().listTail)
            {
               while (Mathf.Round(Pos.transform.position.x) == Mathf.Round(food.transform.position.x) &&
                   Mathf.Round(Pos.transform.position.y) == Mathf.Round(food.transform.position.y))
               {
                    food.transform.position = new Vector2((int)Random.Range(LeftWall.transform.position.x, RightWall.transform.position.x),
                                                  (int)Random.Range(DownWall.transform.position.y, UpWall.transform.position.y));
                    intersects = true;
                    break;
               }
                
            }
            if (!intersects)
            {
                break;
            }
        }    
    }
    // Генерация стен
    void SpawnWalls()
    {
        // Создание объектов
        LeftWall = Instantiate(Resources.Load("LeftWall"), new Vector2(-9 * (int)Size, 0), Quaternion.identity) as GameObject;
        RightWall = Instantiate(Resources.Load("RightWall"), new Vector2(9 * (int)Size, 0), Quaternion.identity) as GameObject;
        UpWall = Instantiate(Resources.Load("UpWall"), new Vector2(0, 5 * (int)Size), Quaternion.identity) as GameObject;
        DownWall = Instantiate(Resources.Load("DownWall"), new Vector2(0, -5 * (int)Size), Quaternion.identity) as GameObject;
        // Изменение размеров стен в соответствии с Size
        LeftWall.transform.localScale    = new Vector3(0.3f,  10.0f * (int)Size, 0.0f);
        RightWall.transform.localScale   = new Vector3(0.3f, -10.0f * (int)Size, 0.0f);
        UpWall.transform.localScale      = new Vector3( 18.0f * (int)Size, 0.3f, 0.0f);
        DownWall.transform.localScale    = new Vector3(-18.0f * (int)Size, 0.3f, 0.0f);
        // Изменение размеров камеры в соответствии с размерами стен
        GameObject.Find("Main Camera").GetComponent<Camera>().orthographicSize = (int)Size * 6;
        // Изменение параметров Point light в соотвествии с размерами поля
        switch((int)Size)
        {
            case 1:
                PtLight.GetComponent<Light>().range = 13.0f;
                PtLight.GetComponent<Light>().intensity = 3.0f;
                PtLight.transform.position = new Vector3(0.0f, 0.0f, -6.0f);
                break;
            case 2:
                PtLight.GetComponent<Light>().range = 33.0f;
                PtLight.GetComponent<Light>().intensity = 3.0f;
                PtLight.transform.position = new Vector3(0.0f, 0.0f, -11.0f);
                break;
            case 3:
                PtLight.GetComponent<Light>().range = 43.0f;
                PtLight.GetComponent<Light>().intensity = 3.0f;
                PtLight.transform.position = new Vector3(0.0f, 0.0f, -15.0f);
                break;
        }
    }
}
