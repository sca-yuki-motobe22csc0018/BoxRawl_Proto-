using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class StageScore : MonoBehaviour
{

    public static int[] scores = new int[9];
    public static string[] scoreDatas =new string[9];
    public int[] tmp=new int[9];//確認用
    [SerializeField] private GameObject check;
    [SerializeField] private Text stageHighScore;
    private void Awake()
    {
        CheckTotalScore();
    }
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
        if(StageSelect.selectNumber!=0 )
        {
            check.SetActive(scores[StageSelect.selectNumber - 1] > 10000);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            for(int i = 0; i < scores.Length;i++)
            {
                PlayerPrefs.SetInt(scoreDatas[i], 0);
                scores[i] = PlayerPrefs.GetInt(scoreDatas[i]);
            }
        }
        else
        {
            for (int i = 0; i < 9; i++)
            {
                scoreDatas[i] = "stage" + i.ToString();
                scores[i] = PlayerPrefs.GetInt(scoreDatas[i]);
                if(StatusUp.selectTypeNumber==i)
                {
                   
                }

            }
            tmp = scores;
            if (StageSelect.selectNumber != 0)
            {
                stageHighScore.text = scores[StageSelect.selectNumber-1].ToString();
            }
        }
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
