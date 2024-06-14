using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RankingManager : MonoBehaviour
{
    [SerializeField] Scrollbar scrollbar;
    bool isRankingScroll;

    void Start()
    {
        isRankingScroll = true;
    }

    void Update()
    {
        rankingScroll();

        if(Input.GetKeyUp(KeyCode.Return))
        {
            goMenu();
        }
    }

    public void goMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void rankingScroll()
    {
        if (isRankingScroll)
        {
            if (scrollbar.value <= 1)
            {
                scrollbar.value += Time.deltaTime / 7;
            }
            else if (scrollbar.value >= 1)
            {
                isRankingScroll = false;
            }
        }
    }
}
