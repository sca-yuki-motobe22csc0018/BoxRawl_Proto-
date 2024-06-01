using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Ranking : MonoBehaviour
{
    [Header("�X�R�A�֌W")]
    int totalScore;

    [Header("�L�����o�X�֌W")]
    [SerializeField] GameObject resultBoard;
    [SerializeField] GameObject nameBoard;
    [SerializeField] GameObject rankingBoard;
    [SerializeField] GameObject gameOverMenu;

    public static bool isScore; //true�̏ꍇ�L�����o�X�\��

    [Header("���O�֌W")]
    public static string PlayerName;
    public InputField nameInputField;

    [Header("���U���g�֌W")]
    [SerializeField] Text resultText;
    float resultScore;
    bool isResult = false;
    enum RankingState
    {
        result = 0,
        name,
        ranking,
        menu
    }
    RankingState rankingState;

    [SerializeField]Scrollbar scrollbar;
    bool isRankingScroll = true;

    // Start is called before the first frame update
    void Start()
    {
        isScore = false;
        resultBoard.SetActive(false);
        nameBoard.SetActive(false);
        rankingBoard.SetActive(false);
        gameOverMenu.SetActive(false);

        PlayerName = null;

        RankingManager.rankingUpdate = false;

        resultScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isScore)
        {
            switch (rankingState)
            {
                case RankingState.result:
                    resultBoard.SetActive(true);
                    nameBoard.SetActive(false);
                    rankingBoard.SetActive(false);
                    gameOverMenu.SetActive(false);
                    Result();
                    break;
                case RankingState.name:
                    resultBoard.SetActive(false);
                    nameBoard.SetActive(true);
                    rankingBoard.SetActive(false);
                    gameOverMenu.SetActive(false);
                    nameInput();
                    break;
                case RankingState.ranking:
                    resultBoard.SetActive(false);
                    nameBoard.SetActive(false);
                    rankingBoard.SetActive(true);
                    gameOverMenu.SetActive(false);
                    ranking();
                    break;
                case RankingState.menu:
                    resultBoard.SetActive(false);
                    nameBoard.SetActive(false);
                    rankingBoard.SetActive(false);
                    gameOverMenu.SetActive(true);
                    gameMenu();
                    break;
            }
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            isScore = true;
        }

    }

    void Result()
    {
        totalScore = 20000;     //�X�R�A�󂯎��
        RankingManager.myScore = totalScore;

        //�J�E���g�A�b�v
        if(resultScore < totalScore)
        {
            resultScore += (totalScore * Time.deltaTime)/4;
            resultText.text = resultScore.ToString("f0");
        }
        else if(resultScore > totalScore) 
        {
            resultScore = totalScore;
            resultText.text = resultScore.ToString("f0");

            isResult = true;
        }


        if(isResult)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (totalScore > RankingManager.rankingScore[9]
                    || RankingManager.rankingScore[9] == null)
                {
                    rankingState = RankingState.name;
                }
                else
                {
                    RankingManager.rankingUpdate = true;
                    rankingState = RankingState.ranking;
                }
            }
        }
    }

    void nameInput()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            PlayerName = nameInputField.text;
        }

        if (PlayerName != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log(PlayerName);
                RankingManager.myName = PlayerName;
                RankingManager.rankingUpdate = true;
                rankingState = RankingState.ranking;
                scrollbar.value = 0.0f;
            }
        }
    }

    void ranking()
    {
        if(isRankingScroll)
        {
            if (scrollbar.value <= 1)
            {
                scrollbar.value += Time.deltaTime / 7;
            }
            else if(scrollbar.value >= 1)
            {
                isRankingScroll = false;
            }
        }
        else if(!isRankingScroll)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                rankingState = RankingState.menu;
            }
        }
    }

    void gameMenu()
    {

    }

}
