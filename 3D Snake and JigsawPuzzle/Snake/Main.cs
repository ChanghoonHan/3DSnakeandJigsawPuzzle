using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    public static Main S;
    public float snakeSpeed = 0.3f; 
    public GameObject cubePrefab;
    public GameObject itemPrefab;
    public List<GameObject> snake = new List<GameObject>();
    public int snakeSize = 1;
    public string snakeDirection = "right";
    public string ChecksnakeDirection = "";
    public bool SnakeCanChangedirection = true;
    public bool isStart = false;
    public bool isGameOver = false;
    public int score = 0;
    public int itemcount = 0;
    public int itemCountForSpeed = 0;

    private void Awake()
    {
        S = this;
        for (int i = 1; i < 4; i++)
        {
            AddCubeLast(CreateCube());
            snake[i].transform.tag = "MainBody";
            snake[i].layer = LayerMask.NameToLayer("MainBody");
            snake[i].transform.position = new Vector3(-i, 0, 0);
        }
    }

    // Use this for initialization
    void Start () {
        for (int i = 0; i < 9; i++)
        {
            SetCube(CreateCube());
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(itemcount < 10)
        {
            SetCube(CreateCube());
        }

        if(itemCountForSpeed+3 == score)
        {
            snakeSpeed -= 0.025f;
            if (score != 0.3f)
            {
                itemCountForSpeed = score;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space) && !isStart)
        {
            isStart = true;
            Invoke("MoveSnake", snakeSpeed);
            StartText.S.SetActiveToFalse();
        }

        if (SnakeCanChangedirection == true)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (snakeDirection != "down")
                {
                    SnakeCanChangedirection = false;
                    snakeDirection = ChecksnakeDirection ="up";
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (snakeDirection != "up")
                {
                    SnakeCanChangedirection = false;
                    snakeDirection = ChecksnakeDirection = "down";
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                if (snakeDirection != "left")
                {
                    SnakeCanChangedirection = false;
                    snakeDirection = ChecksnakeDirection = "right";
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                if (snakeDirection != "right")
                {
                    SnakeCanChangedirection = false;
                    snakeDirection = ChecksnakeDirection = "left";
                }
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (snakeDirection != "back")
                {
                    SnakeCanChangedirection = false;
                    snakeDirection = ChecksnakeDirection = "forward";
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (snakeDirection != "forward")
                {
                    SnakeCanChangedirection = false;
                    snakeDirection = ChecksnakeDirection = "back";
                }
            }
        }
    }

    void MoveSnake()
    {
        Vector3 temp;
        Vector3 temp1;
        Vector3 headPos;
        temp = headPos =snake[0].transform.position;
        if (headPos.x < -10 || headPos.x > 9 || headPos.y < -10 || headPos.y > 9 ||
            headPos.z < -9 || headPos.z > 10)
        {
            GameOver();
            isGameOver = true;
        }

        if (!isGameOver)
        {
            for (int i = 0; i < snakeSize; i++)
            {
                if(ChecksnakeDirection == snakeDirection)
                {
                    SnakeCanChangedirection = true;
                }
                if (i == 0)
                {
                    temp = snake[0].transform.position;
                    switch (snakeDirection) {
                        case "right":
                            snake[0].transform.position += Vector3.right;
                        break;
                        case "left":
                            snake[0].transform.position += Vector3.left;
                            break;
                        case "up":
                            snake[0].transform.position += Vector3.up;
                            break;
                        case "down":
                            snake[0].transform.position += Vector3.down;
                            break;
                        case "forward":
                            snake[0].transform.position += Vector3.forward;
                            break;
                        case "back":
                            snake[0].transform.position += Vector3.back;
                            break;
                    }   
                }
                else {
                    temp1 = snake[i].transform.position;
                    snake[i].transform.position = temp;
                    temp = temp1;
                }

            }

            Invoke("MoveSnake", snakeSpeed);
        }
    }

    GameObject SetCube (GameObject cube) {
        Vector3 cubePos = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-9, 11));
        while (!CheckCubePos(cubePos))
        {
            cubePos = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-9, 11));
        }
        cube.transform.position = cubePos;
            
        itemcount++;
        return cube;
    }

    bool CheckCubePos(Vector3 cubePos)
    {
        bool isnotSamePos = true;

        foreach (GameObject item in snake)
        {
            if(item.transform.position == cubePos)
            {
                isnotSamePos = false;
                break;
            }

        }

        return isnotSamePos;
    }

    public void AddCubeLast(GameObject GO)
    {
        GO.transform.tag = "Body";
        GO.transform.gameObject.layer = LayerMask.NameToLayer("Body");
        snake.Add(GO);
        snakeSize++;
    }

    public void DeleteCubeLast()
    {
        if (snakeSize > 4)
        {
            GameObject DGO = snake[snakeSize - 1];
            snake.RemoveAt(snakeSize - 1);
            Destroy(DGO);
            snakeSize--;
        }
    }

    public GameObject CreateCube()
    {
        float makeItemProb = 0.4f;
        GameObject item = null;
        if (score < 10) {
            item = Instantiate(cubePrefab);
            item.GetComponent<Renderer>().material.color =
                  new Color(Random.value, Random.value, Random.value);
        }
        else
        {
            if(Random.value < makeItemProb)
            {
                item = Instantiate(itemPrefab);
                item.GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                item = Instantiate(cubePrefab);
                item.GetComponent<Renderer>().material.color =
                  new Color(Random.value, Random.value, Random.value);
            }
        }

        item.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
       
        return item;
    }

    public void StageLevelUP()
    {
        snakeSpeed -= 0.02f;
    }

    public void GameOver()
    {
        CancelInvoke("MoveSnake");
        GameoverText.S.GameOverView();
    }
}
