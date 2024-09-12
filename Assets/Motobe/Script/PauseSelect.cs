using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSelect : MonoBehaviour
{
    float sin;
    public static bool levelSel;
    public GameObject[] pos;
    public static int posNum;
    public GameObject timerText;
    public GameObject pauseLvSel;
    public GameObject pauseLvBack;
    public GameObject fade01;
    public GameObject fade02;

    float leftTimer;
    float rightTimer;

    // Start is called before the first frame update
    void Start()
    {
        levelSel = false;
        posNum = 1;
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
            leftTimer = 0;
        }
        if (posNum < 2)
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (posNum == 0)
            {
                PauseWindow.pauseEnd = true;
                this.gameObject.SetActive(false);
            }
            else if (posNum==1)
            {
                PauseLevelSelect.posNum = 0;
                pauseLvSel.SetActive(true);
                pauseLvBack.SetActive(true);
                fade01.SetActive(false);
                fade02.SetActive(true);
                this.gameObject.SetActive(false);
            }else if(posNum==2) 
            {
                //
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

        sin = Mathf.Sin(Time.time * 6);
        if (sin > 0.8f)
        {
            this.gameObject.transform.localScale = new Vector3(0.012f * sin * 1.2f, 0.03f * sin * 1.2f, 1);
        }
        else if (sin < -0.8f)
        {
            this.gameObject.transform.localScale = new Vector3(0.012f * sin * 1.2f, 0.03f * sin * 1.2f, 1);
        }
    }
}
