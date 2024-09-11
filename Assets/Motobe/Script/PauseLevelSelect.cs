using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseLevelSelect : MonoBehaviour
{
    float sin;
    public static bool size;
    public GameObject[] pos;
    public static int posNum;
    public GameObject timerText;
    // Start is called before the first frame update
    void Start()
    {
        size = true;
        posNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //enemyspawner.SetActive(true);
        if (size)
        {
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
            if (Input.GetKeyDown(KeyCode.D))
            {
                if(posNum==0||posNum==1||posNum==2|| posNum == 4 || posNum == 5 || posNum == 6 || posNum == 8 || posNum == 9 || posNum == 10) 
                {
                    posNum += 1;
                }
                if(posNum == 3 || posNum == 7 || posNum == 11)
                {
                    posNum -= 3;
                }
                SEController.select = true;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (posNum == 3 || posNum == 1 || posNum == 2 || posNum == 7 || posNum == 5 || posNum == 6 || posNum == 11 || posNum == 9 || posNum == 10)
                {
                    posNum -= 1;
                }
                if (posNum == 0 || posNum == 4 || posNum == 8)
                {
                    posNum += 3;
                }
                SEController.select = true;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
            }
        }
    }
}
