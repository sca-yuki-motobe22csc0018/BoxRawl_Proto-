using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelRand : MonoBehaviour
{
    //public GameObject[] level;
    public GameObject[] type;
    public static bool rand;
    int random;
    int random2;
    int a;
    // Start is called before the first frame update
    void Start()
    {
        rand = false;
        a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (rand)
        {
            if (a > 11)
            {
                rand = false;
                a = 0;
                return;
            }/*
            for (int i = 0; i < 3; i++)
            {
                level[i].SetActive(false);
            }
            */
            for (int i = 0; i < 11; i++)
            {
                type[i].SetActive(false);
            }
            /*
            random = Random.Range(0, 100);
            if (random < 70)
            {
                level[0].SetActive(true);
            }
            else
            if (random < 95)
            {
                level[1].SetActive(true);
            }
            else
            if (random < 100)
            {
                level[2].SetActive(true);
            }
            */
            random2= Random.Range(0, 8);
            if (random2 == 0)
            {
                type[0].SetActive(true);
                this.tag = type[0].tag;
            }else if (random2 == 1)
            {
                type[1].SetActive(true);
                this.tag = type[1].tag;
            }else if(random2 == 2)
            {
                type[2].SetActive(true);
                this.tag = type[2].tag;
            }else if (random2 == 3)
            {
                type[3].SetActive(true);
                this.tag = type[3].tag;
            }else if (random2 == 4)
            {
                type[4].SetActive(true);
                this.tag = type[4].tag;
            }else if (random2 == 5)
            {
                type[5].SetActive(true);
                this.tag = type[5].tag;
            }else if (random2 == 6)
            {
                type[6].SetActive(true);
                this.tag = type[6].tag;
            }else if( random2 == 7)
            {
                type[7].SetActive(true);
                this.tag = type[7].tag;
            }else if (random2 == 8)
            {
                type[8].SetActive(true);
                this.tag = type[8].tag;
            }
            else if (random2 == 9)
            {
                type[9].SetActive(true);
                this.tag = type[9].tag;
            }
            else if (random2 == 10)
            {
                type[9].SetActive(true);
                this.tag = type[10].tag;
            }

            a++;
        }
    }
}
