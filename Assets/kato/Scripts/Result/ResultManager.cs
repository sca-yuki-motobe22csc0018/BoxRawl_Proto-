using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class ResultManager : MonoBehaviour
{
    public static int totalScore;
    float countScore;
    bool isCountUp;
    int tenScore;
    static float time;   //生き残った時間
    static float timeScore = 10;
    static float timeTotalScore;
    static int level;  //レベル
    static int levelScore = 2000;
    static int levelTotalScore;
    static int enemyKillNum;    //通常サイズの敵を倒した数
    static int enemyKillScore = 200;
    static int enemyKillTotalScore;
    static int smallEnemyKillNum;   //小さいサイズの敵を倒した数
    static int sEnemyKillScore = 100;
    static int sEnemyKillTotalScore;
    int clearScore = 10000;
    [SerializeField] Text[] scoreText;

    [SerializeField] GameObject pressText;

    string myName;
    [SerializeField] InputField nameField;
    [SerializeField] GameObject nameCanvas;

    bool isRank;

    enum Result
    {
        Exp,
        Time,
        Enemy,
        SmallEnemy,
        ClearCheck,
        Total,
        None
    }
    Result result; 

    float counter;

    [SerializeField] RectMask2D mask;

    void Start()
    {
        mask.padding = new Vector4(0, 0, 75, 0);
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
        pressText.SetActive(false);

    }


    void Update()
    {
        counter += Time.deltaTime;
        if (isCountUp)
        {
            scoreDisplay();
        }
        else if(!isCountUp)
        {

            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Menu");
            }
        }

        //if (Input.GetKeyUp(KeyCode.Return))
        //{
        //    SceneManager.LoadScene("Menu");
        //}
    }

    void scoreDisplay()
    {
        switch(result)
        {
            case Result.Exp:
                scoreText[1].DOFade(1,1.0f);
                if(counter >= 0.5f)
                {
                    result = Result.Time;
                }
                break;
            case Result.Time:
                scoreText[2].DOFade(1,1.0f);
                if (counter >= 1.0f)
                {
                    result = Result.Enemy;
                }
                break;
            case Result.Enemy:
                scoreText[3].DOFade(1, 1.0f);
                if (counter >= 1.5f)
                {
                    result = Result.SmallEnemy;
                }
                break;
            case Result.SmallEnemy:
                scoreText[4].DOFade(1, 1.0f);
                if (counter >= 2.0f)
                {
                    result = Result.Total;
                }
                break;
            case Result.Total:
                if (countScore < totalScore)
                {
                    countScore += (totalScore * Time.deltaTime) / 3;
                    scoreText[0].text = countScore.ToString("f0");
                }
                else if (countScore > totalScore)
                {
                    countScore = totalScore;
                    scoreText[0].text = totalScore.ToString("f0");
                    result = Result.ClearCheck;
                }

                if(0 >= totalScore)
                {
                    result = Result.ClearCheck;
                    Debug.Log("yonda");
                }

                if(Input.GetKey(KeyCode.Return))
                {
                    countScore = totalScore;
                    scoreText[0].text = totalScore.ToString("f0");
                    result = Result.ClearCheck;
                }

                break;
            case Result.ClearCheck:
                if (clearScore <= totalScore)
                {
                    mask.padding -= new Vector4(0, 0, ((75 * Time.deltaTime) * 5), 0);
                    if(mask.padding.z < 0)
                    {
                        result = Result.None;
                    }
                }
                else
                {
                    result = Result.None;
                }
                break;
            case Result.None:
                pressText.SetActive(true);
                isCountUp = false;
                break;
            default:
                break;
        }
    }

    void scoreCalculation()
    {
#if false
        //デバッグ用
        time = Random.Range(100,601);
        level = Random.Range(10, 100);
        enemyKillNum = Random.Range(10, 50);
        smallEnemyKillNum = Random.Range(10, 50);
#endif

        time = ScoreManager.timer;
        level = ScoreManager.lvUpCount;
        enemyKillNum = ScoreManager.bigEnemyKillCount;
        smallEnemyKillNum = ScoreManager.smallEnemyKillCount;

        timeTotalScore = (int)Mathf.Floor(time * timeScore);
        levelTotalScore = level * levelScore;
        enemyKillTotalScore = enemyKillNum * enemyKillScore;
        sEnemyKillTotalScore = smallEnemyKillNum * sEnemyKillScore;
        totalScore = (int)timeTotalScore + levelTotalScore + enemyKillTotalScore + sEnemyKillTotalScore;

        //scoreText[0].text = totalScore.ToString();
        scoreText[1].text = level.ToString();
        scoreText[2].text = time.ToString("f2");
        scoreText[3].text = enemyKillNum.ToString();
        scoreText[4].text = smallEnemyKillNum.ToString();
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

    public static void SetScore (float _time, int _Exp , int _enemyKill , int _senemyKill)
    {
        time = _time;
        level = _Exp;
        enemyKillNum = _enemyKill;
        smallEnemyKillNum = _senemyKill;
    }

    public static int GetTotalScore(float _time, int _Exp, int _enemyKill, int _senemyKill)
    {
        time = _time;
        level = _Exp;
        enemyKillNum = _enemyKill;
        smallEnemyKillNum = _senemyKill;
        timeTotalScore = (time * timeScore);
        levelTotalScore = level * levelScore;
        enemyKillTotalScore = enemyKillNum * enemyKillScore;
        sEnemyKillTotalScore = smallEnemyKillNum * sEnemyKillScore;
        totalScore = (int)timeTotalScore + levelTotalScore + enemyKillTotalScore + sEnemyKillTotalScore;
        return totalScore;
    }
}
