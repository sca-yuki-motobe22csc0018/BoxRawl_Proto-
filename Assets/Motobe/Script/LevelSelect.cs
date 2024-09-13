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
    public static bool notLevelUp;
    public GameObject timerText;

    public static int Level_Speed;
    public static int Level_Jump;
    public static int Level_InvincibleDash;
    public static int Level_Heal;
    public static int Level_InvincibleT;
    public static int Level_Diffusion;
    public static int Level_ShockWaveWall;
    public static int Level_ShockWaveGround;
    public static int Level_Chain;
    public static int Level_Bunshin;
    public static int Level_Bullet;
    public static int Level_Barrier;

    // Start is called before the first frame update
    void Start()
    {
        notLevelUp = false;
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

        Level_Speed = 0;
        Level_Jump = 0;
        Level_InvincibleDash = 0;
        Level_Heal = 0;
        Level_InvincibleT = 0;
        Level_Diffusion = 0;
        Level_ShockWaveWall = 0;
        Level_ShockWaveGround = 0;
        Level_Chain = 0;
        Level_Bunshin = 0;
        Level_Bullet = 0;
        Level_Barrier = 0;

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
                if (!notLevelUp)
                {
                    notLevelUp = true;
                    int num;
                    num = posNum;

                    if (pos[num].tag == "Level_StateS")
                    {
                        if (Level_Speed < 3)
                        {
                            PlayerMove.PlusSpeed += 3.0f;
                            Level_Speed += 1;
                        }
                        
                    }
                    if (pos[num].tag == "Level_StateJ")
                    {
                        if (Level_Jump < 3)
                        {
                            PlayerMove.PlusJumpForce += 3.0f;
                            Level_Jump += 1;
                        }
                        
                    }
                    if (pos[num].tag == "Level_InvincibleT")
                    {
                        if (Level_InvincibleT < 3)
                        {
                            PlayerMove.PlusInvincibleTime += 8;
                            Level_InvincibleT += 1;
                        }
                        
                    }
                    if (pos[num].tag == "Level_InvincibleD")
                    {
                        if (Level_InvincibleDash < 3)
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
                            Level_InvincibleDash += 1;
                        }
                        
                    }
                    if (pos[num].tag == "Level_Bunshin")
                    {
                        if (Level_Bunshin < 3)
                        {
                            if (ParyController.DekoifreMax == 5)
                            {
                                ParyController.DekoifreMax = 100;
                            }
                            if (ParyController.DekoifreMax == 1)
                            {
                                ParyController.DekoifreMax = 5;
                            }
                            if (ParyController.DekoifreMax == 0)
                            {
                                ParyController.DekoifreMax = 1;
                            }
                            Level_Bunshin += 1;
                        }
                        
                    }
                    if (pos[num].tag == "Level_Barrier")
                    {
                        if (Level_Barrier < 3)
                        {
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
                            Level_Barrier += 1;
                        }
                        
                    }
                    if (pos[num].tag == "Level_Heal")
                    {
                        if (Level_Heal < 3)
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
                            Level_Heal += 1;
                        }
                        
                    }
                    if (pos[num].tag == "Level_Diffusion")
                    {
                        if (Level_Diffusion < 3)
                        {
                            MagnetismManager.MagnetismLv++;
                            Level_Diffusion += 1;
                        }
                        
                    }
                    if (pos[num].tag == "Level_ShockWaveGround")
                    {
                        if (Level_ShockWaveGround < 3)
                        {
                            ShockWave.dropShockWaveLv++;
                            Level_ShockWaveGround += 1;
                        }
                        
                    }
                    if (pos[num].tag == "Level_ShockWaveWall")
                    {
                        if (Level_ShockWaveWall < 3)
                        {
                            ShockWave.wallShockWaveLv++;
                            Level_ShockWaveWall += 1;
                        }
                        
                    }
                    if (pos[num].tag == "Level_Chain")
                    {
                        if (Level_Chain < 3)
                        {
                            ChainAttack.chainLv++;
                            Level_Chain += 1;
                        }
                        
                    }
                    if (pos[num].tag == "Level_Bullet")
                    {
                        if (Level_Bullet < 3)
                        {
                            JumpShot.shotLv++;
                            Level_Bullet += 1;
                        }
                        
                    }
                    Debug.Log(pos[num].tag);
                    //timerText.SetActive(true);
                    SEController.get = true;
                    PlayerMove.PlayerDead = true;
                    levelUpEnd = true;
                }
                
            }
        }
    }
}
