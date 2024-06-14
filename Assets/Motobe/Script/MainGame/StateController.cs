using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public GameObject[] Level01;
    public GameObject[] Level02;
    public GameObject[] Level03;
    public GameObject[] Level04;
    public GameObject[] Level05;
    public GameObject[] Level06;

    public static int level01;
    public static int level02;
    public static int level03;
    public static int level04;
    public static int level05;
    public static int level06;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Level01[i].SetActive(false);
            Level02[i].SetActive(false);
            Level03[i].SetActive(false);
            Level04[i].SetActive(false);
            Level05[i].SetActive(false);
            Level06[i].SetActive(false);
        }
        level01 = 0;
        level02 = 0;
        level03 = 0;
        level04 = 0;
        level05 = 0;
        level06 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (level01 == 1)
        {
            Level01[0].SetActive(true);
        }
        if (level01 == 2)
        {
            Level01[1].SetActive(true);
        }
        if (level01 == 3)
        {
            Level01[2].SetActive(true);
        }

        if (level02 == 1)
        {
            Level02[0].SetActive(true);
        }
        if(level02 == 2)
        {
            Level02[1].SetActive(true);
        }
        if(level02==3)
        {
            Level02[2].SetActive(true);
        }

        if (level03 == 1)
        {
            Level03[0].SetActive(true);
        }
        if(level03 == 2)
        {
            Level03[1].SetActive(true);
        }
        if (level03 == 3)
        {
            Level03[2].SetActive(true);
        }

        if (level04 == 1)
        {
            Level04[0].SetActive(true);
        }
        if (level04 == 2)
        {
            Level04[1].SetActive(true);
        }
        if (level04 == 3)
        {
            Level04[2].SetActive(true);
        }

        if (level05 == 1)
        {
            Level05[0].SetActive(true);
        }
        if (level05 == 2)
        {
            Level05[1].SetActive(true);
        }
        if (level05 == 3)
        {
            Level05[2].SetActive(true);
        }

        if (level06 == 1)
        {
            Level06[0].SetActive(true);
        }
        if (level06 == 2)
        {
            Level06[1].SetActive(true);
        }
        if (level06 == 3)
        {
            Level06[2].SetActive(true);
        }
    }
}
