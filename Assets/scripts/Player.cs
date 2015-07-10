using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public GameObject snake;

    public float SpawnTime = 0.5f;


	// Use this for initialization
	void Start () {
        Invoke("MoveSnake",SpawnTime);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void MoveSnake()
    {
        
     
        Invoke("MoveSnake", SpawnTime);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            print("Left нажато");
            transform.Rotate(new Vector3(0,0, 90));
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            print("Right нажато");
            transform.Rotate(new Vector3(0, 0,-90));
        }
        transform.position += transform.up;
    }

    
}
