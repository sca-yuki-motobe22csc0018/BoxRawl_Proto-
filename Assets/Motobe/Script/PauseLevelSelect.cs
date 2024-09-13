using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PauseLevelSelect : MonoBehaviour
{
    float sin;
    public static bool levelSel;
    public GameObject[] pos;
    public static int posNum;
    public GameObject timerText;
    public GameObject back;
    public GameObject fade01;
    public GameObject fade02;
    public GameObject pauseSel;

    float leftTimer;
    float rightTimer;
    float upTimer;
    float downTimer;
    public GameObject CardBack;
    public GameObject CardOmote;
    bool change;

    // Start is called before the first frame update
    void Start()
    {
        change=false;
        levelSel = false;
        posNum = 0;
        leftTimer = 0;
        rightTimer = 0;
        upTimer = 0;
        downTimer = 0;
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
        if (Input.GetKeyUp(KeyCode.W))
        {
            upTimer = 0;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            downTimer = 0;
        }
        if (posNum < 12)
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

        
        if (posNum<4)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                posNum += 4;
                if (Input.GetKey(KeyCode.S))
                {
                    downTimer += Time.deltaTime;
                }
                if (downTimer > 0.4f)
                {
                    posNum += 4;
                    SEController.select = true;
                    downTimer = 0.3f;
                }
                return;
            }
        }
        if (posNum > 3 && posNum < 8)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                posNum -= 4;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                posNum += 4;
                return;
            }
            if (Input.GetKey(KeyCode.S))
            {
                downTimer += Time.deltaTime;
            }
            if (downTimer > 0.4f)
            {
                posNum += 4;
                SEController.select = true;
                downTimer = 0.3f;
            }
            if (Input.GetKey(KeyCode.W))
            {
                upTimer += Time.deltaTime;
            }
            if (upTimer > 0.4f)
            {
                posNum -= 4;
                SEController.select = true;
                upTimer = 0.3f;
            }
        }
        if (posNum > 7 && posNum < 12)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                posNum -= 4;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                posNum = 12;
                return;
            }
            if (Input.GetKey(KeyCode.S))
            {
                downTimer += Time.deltaTime;
            }
            if (downTimer > 0.4f)
            {
                posNum =12;
                SEController.select = true;
                downTimer = 0.3f;
            }
            if (Input.GetKey(KeyCode.W))
            {
                upTimer += Time.deltaTime;
            }
            if (upTimer > 0.4f)
            {
                posNum -= 4;
                SEController.select = true;
                upTimer = 0.3f;
            }
        }
        if (posNum == 12)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                posNum =11;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SEController.enter = true;
                CardClose();
                back.SetActive(false);
                pauseSel.SetActive(true);
                fade01.SetActive(true);
                fade02.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }

        if (posNum < 12)
        {
            if (Input.GetKeyDown(KeyCode.Space) && change == false)
            {
                SEController.enter = true;
                CardOpen();
                change = true;
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
        else if (posNum == 12)
        {
            this.transform.position = new Vector3(pos[12].transform.position.x, pos[12].transform.position.y, 1);
        }

        sin = Mathf.Sin(Time.time * 6);
        if (sin > 0.8f)
        {
            this.gameObject.transform.localScale = new Vector3(0.036f * sin * 1.2f, 0.075f * sin * 1.2f, 1);
        }
        else if (sin < -0.8f)
        {
            this.gameObject.transform.localScale = new Vector3(0.036f * sin * 1.2f, 0.075f * sin * 1.2f, 1);
        }
    }
    void CardOpen()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(CardOmote.transform.DORotate(new Vector3(0, 90, 0), 0.15f));
        sequence.JoinCallback(() => Change());
        sequence.Append(CardBack.transform.DORotate(new Vector3(0, 0, 0), 0.15f));
        sequence.JoinCallback(() => CardSE());

        sequence.AppendInterval(0.05f);
        sequence.JoinCallback(() => Change2());

        sequence.Append(CardBack.transform.DORotate(new Vector3(0, 90, 0), 0.15f));

        sequence.Append(CardOmote.transform.DORotate(new Vector3(0, 0, 0), 0.15f));
        sequence.JoinCallback(() => CardSE());
        sequence.AppendInterval(0.05f);
        sequence.AppendCallback(() => Change3());
    }

    void CardClose()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(CardOmote.transform.DORotate(new Vector3(0, 90, 0), 0.15f));

        sequence.Append(CardBack.transform.DORotate(new Vector3(0, 0, 0), 0.15f));
        sequence.JoinCallback(() => CardSE());
    }

    private void CardSE()
    {
        SEController.changeCard = true;
    }
    private void Change()
    {
        LevelCard.level = posNum;
    }
    private void Change2()
    {
        LevelCard.change = true;
    }
    private void Change3()
    {
        change = false;
    }
}
