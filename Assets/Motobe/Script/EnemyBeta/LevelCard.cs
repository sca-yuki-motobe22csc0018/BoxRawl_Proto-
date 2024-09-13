using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCard : MonoBehaviour
{
    public GameObject[] type;
    public static bool change;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            type[i].SetActive(false);
        }
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
            type[PauseLevelSelect.posNum].SetActive(true);
            change = false;
        }
    }
}
