using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class StageScore : MonoBehaviour
{

    public static int[] scores = new int[9];
    public static string[] scoreDatas =new string[9];
    public static bool lastStage;
    public int[] tmp=new int[9];//確認用
    [SerializeField] private GameObject check;
    [SerializeField] private Text stageHighScore;
    private int clearStageCount;
    private void Awake()
    {
        CheckTotalScore();
    }
    // Start is called before the first frame update
    void Start()
    {
        lastStage=false;
        clearStageCount=0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))//スコアリセット
        //{
        //    for(int i = 0; i < scores.Length;i++)
        //    {
        //        PlayerPrefs.SetInt(scoreDatas[i], 0);
        //        scores[i] = PlayerPrefs.GetInt(scoreDatas[i]);
        //    }
        //}
        if (StageSelect.selectNumber != 0)
        {
            check.SetActive(scores[StageSelect.selectNumber - 1] > 10000);
        }
        else
        {
            for (int i = 0; i < 9; i++)
            {
                scoreDatas[i] = "stage" + i.ToString();
                scores[i] = PlayerPrefs.GetInt(scoreDatas[i]);
            }
            tmp = scores;
        }
        stageHighScore.text = scores[StageSelect.selectNumber - 1].ToString();
        for (int i = 0; i < 8; i++)
        {
            if (scores[i] >= 10000)
            {
                clearStageCount++;
            }
            if (clearStageCount >= 8)
            {
                lastStage = true;
            }
        }
        clearStageCount = 0;
    }

    public static void CheckTotalScore()
    {
        int tmpScore = ScoreManager.bigEnemyKillCount * 200+ScoreManager.smallEnemyKillCount*100
            +(int)ScoreManager.timer*10+ScoreManager.lvUpCount*2000;
        for(int i=0;i<scores.Length;i++)
        {
            if(StageSelect.selectNumber-1==i)
            {
                if (tmpScore > scores[i])
                {
                    PlayerPrefs.SetInt(scoreDatas[i], tmpScore);
                }
            }
        }
       
    }
    
}　　　
