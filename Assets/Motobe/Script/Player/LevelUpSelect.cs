using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class LevelUpSelect : MonoBehaviour
{
    public GameObject Select;
    public GameObject SelectBackCenter;
    public GameObject SelectBackRight;
    public GameObject SelectBackLeft;

    public GameObject Select2;
    public GameObject Select2BackRight;
    public GameObject Select2BackLeft;

    public GameObject[] Level;
    bool conf;
    public GameObject ConfirmWindow;
    public GameObject EnemySpawner;
    int set;
    int set2;
    int dir;
    public GameObject Player;
    public GameObject DestroyObj;
    

    // Start is called before the first frame update
    void Start()
    {
        conf = false;
        set = 2;
        set2 = 0;
        dir = 0;
        ConfirmWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!conf)
        {
            if (set == 1)
            {
                if (SelectBackLeft.transform.position.x < Select.transform.position.x && dir == -1)
                {
                    Select.transform.position -= new Vector3(75f * Time.deltaTime, 0, 0);
                }
            }
            if (set == 2)
            {
                if (SelectBackCenter.transform.position.x < Select.transform.position.x && dir == -1)
                {
                    Select.transform.position += new Vector3(-75f * Time.deltaTime, 0, 0);
                }
                if (SelectBackCenter.transform.position.x > Select.transform.position.x && dir == 1)
                {
                    Select.transform.position += new Vector3(75f * Time.deltaTime, 0, 0);
                }
            }
            if (set == 3)
            {
                if (SelectBackRight.transform.position.x > Select.transform.position.x && dir == 1)
                {
                    Select.transform.position += new Vector3(75f * Time.deltaTime, 0, 0);
                }
            }

            if (Input.GetKeyDown(KeyCode.A) && set >= 2)
            {
                set -= 1;
                dir = -1;
            }
            if (Input.GetKeyDown(KeyCode.D) && set <= 2)
            {
                set += 1;
                dir = 1;
            }
            
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ConfirmWindow.SetActive(true); 
                conf = true;
            }
        }
        else
        {
            if (set2 == 0)
            {
                if (Select2BackLeft.transform.position.x < Select2.transform.position.x)
                {
                    Select2.transform.position -= new Vector3(75f * Time.deltaTime, 0, 0);
                }
            }
            if (set2 == 1)
            {
                if (Select2BackRight.transform.position.x > Select2.transform.position.x)
                {
                    Select2.transform.position += new Vector3(75f * Time.deltaTime, 0, 0);
                }

            }
            if (Input.GetKeyDown(KeyCode.A) && set2 ==1)
            {
                set2 = 0;
                dir = -1;
            }
            if (Input.GetKeyDown(KeyCode.D) && set2 ==0)
            {
                set2 = 1;
                dir = 1;
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                conf = false;
                if (set2 == 0)
                {
                    set = 2;
                    dir = 0;
                    set2 = 0;
                    Select.transform.position = SelectBackCenter.transform.position;
                    Select2.transform.position = Select2BackLeft.transform.position;
                    ConfirmWindow.SetActive(false);
                }
                if (set2 == 1)
                {
                    if (set == 1)
                    {
                        if (StateController.level01 < 3)
                        {
                            PlayerMove.PlusSpeed += 3.3f;
                            StateController.level01 += 1;
                        }
                        
                    }else if(set == 2)
                    {
                        if (StateController.level02 < 3)
                        {
                            PlayerMove.PlusJumpForce += 3.3f;
                            StateController.level02 += 1;
                        }
                        
                    }
                    else if (set == 3)
                    {
                        if (StateController.level03 < 3)
                        {
                            PlayerMove.PlusInvincibleTime += 4;
                            StateController.level03 += 1;
                        }
                        
                    }
                    set = 2;
                    dir = 0;
                    set2 = 0;
                    Select.transform.position = SelectBackCenter.transform.position;
                    Select2.transform.position = Select2BackLeft.transform.position;
                    EnemySpawner.SetActive(true);
                    ConfirmWindow.SetActive(false);
                    PlayerMove.blink = true;
                    PlayerMove.PlayerDead = false;
                    DestroyObj.SetActive(false);
                    this.gameObject.SetActive(false);

                }

            }
         }
    }
}
