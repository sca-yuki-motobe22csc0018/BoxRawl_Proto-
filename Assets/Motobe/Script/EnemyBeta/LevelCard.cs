using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCard : MonoBehaviour
{
    public GameObject[] type;
    public GameObject[] thisLevel;
    public static bool change;
    public static int level;
    int Level;

    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        for (int i = 0; i < 12; i++)
        {
            type[i].SetActive(false);
        }
        for (int i = 0; i < 2; i++)
        {
            thisLevel[i].SetActive(false);
        }
        Level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (change)
        {
            for (int i = 0; i < 12; i++)
            {
                type[i].SetActive(false);
            }
            type[level].SetActive(true);

            for (int i = 0; i < 2; i++)
            {
                thisLevel[i].SetActive(false);
            }
            if (level == 0)
            {
                Level = LevelSelect.Level_Speed;
            }
            if (level == 1)
            {
                Level = LevelSelect.Level_Jump;
            }
            if (level == 2)
            {
                Level = LevelSelect.Level_InvincibleDash;
            }
            if (level == 3)
            {
                Level = LevelSelect.Level_Heal;
            }
            if (level == 4)
            {
                Level = LevelSelect.Level_InvincibleT;
            }
            if (level == 5)
            {
                Level = LevelSelect.Level_Diffusion;
            }
            if (level == 6)
            {
                Level = LevelSelect.Level_ShockWaveWall;
            }
            if (level == 7)
            {
                Level = LevelSelect.Level_ShockWaveGround;
            }
            if (level == 8)
            {
                Level = LevelSelect.Level_Chain;
            }
            if (level == 9)
            {
                Level = LevelSelect.Level_Bunshin;
            }
            if (level == 10)
            {
                Level = LevelSelect.Level_Bullet;
            }
            if (level == 11)
            {
                Level = LevelSelect.Level_Barrier;
            }

            if (Level == 1)
            {
                thisLevel[0].SetActive(true);
            }
            if (Level == 2)
            {
                thisLevel[0].SetActive(true);
                thisLevel[1].SetActive(true);
            }
            if (Level >= 3)
            {
                thisLevel[0].SetActive(true);
                thisLevel[1].SetActive(true);
                thisLevel[2].SetActive(true);
            }
            change = false;
        }
    }
}
