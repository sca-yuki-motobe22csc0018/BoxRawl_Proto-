using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseLevelSelect : MonoBehaviour
{
    float sin;
    public static bool levelSel;
    public GameObject[] pos;
    public static int posNum;
    public GameObject timerText;

    bool left;
    bool right;
    float leftTimer;
    float rightTimer;

    // Start is called before the first frame update
    void Start()
    {
        levelSel = false;
        posNum = 0;
        left = false;
        right = false;
        leftTimer = 0;
        rightTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            rightTimer = 0;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            left = false;
            leftTimer = 0;
        }
        if (posNum < 11)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                posNum += 1;
                SEController.select = true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rightTimer += Time.deltaTime;
            }
            if (rightTimer > 0.4f)
            {
                posNum += 1;
                SEController.select = true;
                rightTimer = 0.3f;
            }
        }
        if (posNum > 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                posNum -= 1;
                SEController.select = true;
            }
            if (Input.GetKey(KeyCode.A))
            {
                leftTimer += Time.deltaTime;
            }
            if (leftTimer > 0.4f)
            {
                posNum -= 1;
                SEController.select = true;
                leftTimer = 0.3f;
            }
        }



        if (posNum == 0)
        {
            this.transform.position = new Vector3(pos[0].transform.position.x, pos[0].transform.position.y, 1);
        }
        else if (posNum == 1)
        {
            this.transform.position = new Vector3(pos[1].transform.position.x, pos[1].transform.position.y, 1);
        }
        else if (posNum == 2)
        {
            this.transform.position = new Vector3(pos[2].transform.position.x, pos[2].transform.position.y, 1);
        }
        else if (posNum == 3)
        {
            this.transform.position = new Vector3(pos[3].transform.position.x, pos[3].transform.position.y, 1);
        }
        else if (posNum == 4)
        {
            this.transform.position = new Vector3(pos[4].transform.position.x, pos[4].transform.position.y, 1);
        }
        else if (posNum == 5)
        {
            this.transform.position = new Vector3(pos[5].transform.position.x, pos[5].transform.position.y, 1);
        }
        else if (posNum == 6)
        {
            this.transform.position = new Vector3(pos[6].transform.position.x, pos[6].transform.position.y, 1);
        }
        else if (posNum == 7)
        {
            this.transform.position = new Vector3(pos[7].transform.position.x, pos[7].transform.position.y, 1);
        }
        else if (posNum == 8)
        {
            this.transform.position = new Vector3(pos[8].transform.position.x, pos[8].transform.position.y, 1);
        }
        else if (posNum == 9)
        {
            this.transform.position = new Vector3(pos[9].transform.position.x, pos[9].transform.position.y, 1);
        }
        else if (posNum == 10)
        {
            this.transform.position = new Vector3(pos[10].transform.position.x, pos[10].transform.position.y, 1);
        }
        else if (posNum == 11)
        {
            this.transform.position = new Vector3(pos[11].transform.position.x, pos[11].transform.position.y, 1);
        }

        sin = Mathf.Sin(Time.time * 6);
        if (sin > 0.8f)
        {
            this.gameObject.transform.localScale = new Vector3(0.85f * sin * 1.2f, 0.85f * sin * 1.2f, 1);
        }
        else if (sin < -0.8f)
        {
            this.gameObject.transform.localScale = new Vector3(0.85f * sin * 1.2f, 0.85f * sin * 1.2f, 1);
        }
    }

}
