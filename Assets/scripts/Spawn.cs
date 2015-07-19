using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
    public GameObject food; // объект еда
    public GameObject LeftWall;// объект Левая граница
    public GameObject UpWall;// объект Верхняя граница
    public GameObject RightWall;// объект Правая граница
    public GameObject DownWall;// объект Нижняя граница
   
	void Start () {
	    SpawnWalls();
        SpawnFood();
	}
	
	// Update is called once per frame
	void Update () {
     
	
	}
    public void SpawnFood()
    {
        // Генерация еды в пределах координат X и Y стен
        int x = (int)Random.Range(LeftWall.transform.position.x, RightWall.transform.position.x);
        int y = (int)Random.Range(DownWall.transform.position.y, UpWall.transform.position.y);
        food = Instantiate(Resources.Load("Food"), new Vector2(x, y), Quaternion.identity) as GameObject;
    }
    // Генерация стен
    void SpawnWalls()
    {
        LeftWall = Instantiate(Resources.Load("LeftWall"), new Vector2(-9, 0), Quaternion.identity) as GameObject;
        RightWall = Instantiate(Resources.Load("RightWall"), new Vector2(9, 0), Quaternion.identity) as GameObject;
        UpWall = Instantiate(Resources.Load("UpWall"), new Vector2(0, 5), Quaternion.identity) as GameObject;
        DownWall = Instantiate(Resources.Load("DownWall"), new Vector2(0, -5), Quaternion.identity) as GameObject;
    }
}
