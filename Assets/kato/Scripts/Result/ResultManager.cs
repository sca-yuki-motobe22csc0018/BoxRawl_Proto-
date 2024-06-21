using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class ResultManager : MonoBehaviour
{
    public int totalScore;
    float countScore;
    bool isCountUp;
    int tenScore;
    static float time;   //生き残った時間
    int timeScore;
    static int ExPoint;//経験値
    int ExpScore;
    [SerializeField] Text[] scoreText;

    string myName;
    [SerializeField] InputField nameField;
    [SerializeField] GameObject nameCanvas;

    bool isRank;

    enum Result
    {
        Exp,
        Time,
        Total
    }
    Result result; 

    float counter;
    void Start()
    {
        PlayerSkin.Rota = false;
        result = Result.Exp;
        nameCanvas.SetActive(false);
        countScore = 0;
        isCountUp = true;

        myName = null;

        tenScore = RankingSet.getTenScore();
        Debug.Log(tenScore);

        scoreText[0].text = "0";
        for (int i = 1; i < scoreText.Length; i++) 
        {
            scoreText[i].color = new Color(0, 0, 0, 0);
        }

        scoreCalculation();

        counter = 0;


    }


    void Update()
    {
        counter += Time.deltaTime;
        if (isCountUp)
        {
            scoreCountUp();
        }
        else if(!isCountUp)
        {
            //if(totalScore > tenScore)
            //{
            //    if (Input.GetKeyUp(KeyCode.A))
            //    {
            //        nameCanvas.SetActive(true);
            //    }
            //}
            //else
            //{
            //    if (Input.GetKeyUp(KeyCode.A))
            //    {
            //        SceneManager.LoadScene("Menu");
            //    }
            //}

            if (Input.GetKeyUp(KeyCode.Return))
            {
                SceneManager.LoadScene("Menu");
            }
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void scoreCountUp()
    {
        switch(result)
        {
            case Result.Exp:
                scoreText[1].DOFade(1,1.0f);
                if(counter >= 1.0f)
                {
                    result = Result.Time;
                }
                break;
            case Result.Time:
                scoreText[2].DOFade(1,1.0f);
                if (counter >= 1.5f)
                {
                    result = Result.Total;
                }
                break;
            case Result.Total:
                if (countScore < totalScore)
                {
                    countScore += (totalScore * Time.deltaTime) / 7;
                    scoreText[0].text = countScore.ToString("f0");
                }
                else if (countScore > totalScore)
                {
                    countScore = totalScore;
                    scoreText[0].text = totalScore.ToString("f0");
                    isCountUp = false;
                    result = default(Result);
                }

                if(Input.GetKey(KeyCode.O))
                {
                    countScore = totalScore;
                    scoreText[0].text = totalScore.ToString("f0");
                    isCountUp = false;
                    result = default(Result);
                }
                break;
            default:
                break;
        }
    }

    void scoreCalculation()
    {
        //timeScore = (int)Mathf.Floor(time * 1000);
        //ExpScore = ExPoint * 1000;
        //totalScore = timeScore + ExpScore;

        //デバッグ用
        timeScore = 5000;
        ExpScore = 6000;
        totalScore = timeScore + ExpScore;

        //scoreText[0].text = totalScore.ToString();
        scoreText[1].text = ExpScore.ToString();
        scoreText[2].text = timeScore.ToString();
    }

    void nameInput()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            myName = nameField.text;
            Debug.Log(myName);
            RankingSet.setScore(totalScore,myName);
            RankingSet.rankingUpdate = true;
        }
    }

    public static void SetScore (float _time, int _Exp)
    {
        time = _time;
        ExPoint = _Exp;
    }
}
