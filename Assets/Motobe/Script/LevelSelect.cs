using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    float sin;
    public static bool size;
    public GameObject[] pos;
    public static int posNum;
    public static bool levelUpEnd;
    public GameObject Heal;
    public GameObject[] HealCount;
    public GameObject Guard;
    public GameObject[] GuardCount;
    bool heal;
    int healLevel;
    bool guard;
    int guardLevel;
    public GameObject timerText;
    // Start is called before the first frame update
    void Start()
    {
        levelUpEnd = false;
        size = false;
        posNum = 1;
        Heal.SetActive(false);
        heal = false;
        for (int i = 0; i < 6; i++)
        {
            HealCount[i].SetActive(false);
        }
        healLevel = 0;
        Guard.SetActive(false);
        guard = false;
        for (int i = 0; i < 6; i++)
        {
            GuardCount[i].SetActive(false);
        }
        guardLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //enemyspawner.SetActive(true);
        if (size)
        {
            if (posNum == 0)
            {
                this.transform.position = new Vector3(pos[0].transform.position.x, pos[0].transform.position.y,1); 
            }else if (posNum == 1)
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
                this.gameObject.transform.localScale = new Vector3(14 * sin * 1.2f, 12 * sin * 1.2f, 1);
            }
            else if (sin < -0.8f)
            {
                this.gameObject.transform.localScale = new Vector3(14 * sin * 1.2f, 12 * sin * 1.2f, 1);
            }
            if (Input.GetKeyDown(KeyCode.A) && posNum > 0)
            {
                SEController.select = true;
                posNum -= 1;
            }
            if (Input.GetKeyDown(KeyCode.D) && posNum < 2)
            {
                SEController.select = true;
                posNum += 1;
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                int num;
                num = posNum;
                
                if (pos[num].tag == "Level_StateS")
                {
                    PlayerMove.PlusSpeed += 2.0f;
                }
                if (pos[num].tag == "Level_StateJ")
                {
                    PlayerMove.PlusJumpForce += 2.0f;
                }
                if (pos[num].tag == "Level_InvincibleT")
                {
                    PlayerMove.PlusInvincibleTime += 4;
                }
                if (pos[num].tag == "Level_InvincibleD")
                {
                    PlayerMove.DashBarrier = true;
                    if (PlayerMove.DashBarrierTime == 4)
                    {
                        PlayerMove.DashBarrierTime = 2;
                    }
                    if (PlayerMove.DashBarrierTime == 5)
                    {
                        PlayerMove.DashBarrierTime = 4;
                    }
                    if (PlayerMove.DashBarrierTime == 0)
                    {
                        PlayerMove.DashBarrierTime = 5;
                    }
                    
                    

                }
                if (pos[num].tag == "Level_Bunshin")
                {
                    if (ParyController.DekoifreMax == 0)
                    {
                        ParyController.DekoifreMax = 1;
                    }
                    if (ParyController.DekoifreMax == 1)
                    {
                        ParyController.DekoifreMax = 5;
                    }
                    if (ParyController.DekoifreMax == 5)
                    {
                        ParyController.DekoifreMax = 100;
                    }
                }
                if (pos[num].tag == "Level_Barrier")
                {
                    if (guardLevel == 3)
                    {
                        //Rota.speed -= 1;
                    }
                    if (guardLevel == 2)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            GuardCount[i].SetActive(false);
                        }
                        GuardCount[3].SetActive(true);
                        GuardCount[4].SetActive(true);
                        GuardCount[5].SetActive(true);
                        guardLevel = 3;
                    }
                    if (guardLevel == 1)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            GuardCount[i].SetActive(false);
                        }
                        GuardCount[1].SetActive(true);
                        GuardCount[2].SetActive(true);
                        guardLevel = 2;
                    }
                    if (!guard)
                    {
                        guard = true;
                        Guard.SetActive(true);
                        guardLevel = 1;
                        GuardCount[0].SetActive(true);
                    }
                }
                if (pos[num].tag == "Level_Heal")
                {
                    if (healLevel == 3)
                    {
                        //Rota.speed -= 1;
                    }
                    if (healLevel == 2)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            HealCount[i].SetActive(false);
                        }
                        HealCount[3].SetActive(true);
                        HealCount[4].SetActive(true);
                        HealCount[5].SetActive(true);
                        healLevel = 3;
                    }
                    if (healLevel == 1)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            HealCount[i].SetActive(false);
                        }
                        HealCount[1].SetActive(true);
                        HealCount[2].SetActive(true);
                        healLevel = 2;
                    }
                    if (!heal)
                    {
                        heal = true;
                        Heal.SetActive(true);
                        healLevel = 1;
                        HealCount[0].SetActive(true);
                    }
                }
                if (pos[num].tag == "Level_Diffusion")
                {
                    MagnetismManager.MagnetismLv++;
                }
                if (pos[num].tag == "Level_Suction")
                {
                    
                }
                if (pos[num].tag == "Level_ShockWaveGround")
                {

                }
                if (pos[num].tag == "Level_ShockWaveWall")
                {

                }
                if (pos[num].tag == "Level_Chain")
                {
                    ChainAttack.chainLv++;
                }
                if (pos[num].tag == "Level_Bullet")
                {
                    JumpShot.shotLv++;
                }
                Debug.Log(pos[num].tag);
                timerText.SetActive(true);
                SEController.get = true;
                PlayerMove.PlayerDead = true;
                levelUpEnd = true;
            }
        }
    }
}
