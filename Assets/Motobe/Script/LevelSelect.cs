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
    // Start is called before the first frame update
    void Start()
    {
        levelUpEnd = false;
        size = false;
        posNum = 1;
        // 0 1 2
    }

    // Update is called once per frame
    void Update()
    {
        
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                int num;
                num = posNum;

                if (pos[num].tag == "Level_State")
                {
                    PlayerMove.PlusJumpForce += 2.0f;
                    PlayerMove.PlusSpeed += 2.0f;
                }
                if (pos[num].tag == "Level_Invincible")
                {
                    PlayerMove.PlusInvincibleTime += 4;
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

                }
                if (pos[num].tag == "Level_Heal")
                {

                }
                if (pos[num].tag == "Level_Diffusion")
                {

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

                }
                Debug.Log(pos[num].tag);
                SEController.get = true;
                levelUpEnd = true;
            }
        }
    }
}
