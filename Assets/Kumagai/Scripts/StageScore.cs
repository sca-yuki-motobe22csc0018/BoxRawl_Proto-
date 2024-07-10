using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class StageScore : MonoBehaviour
{

    public static int[] scores = new int[9];
    public static string[] scoreDatas =new string[9];
    public int[] tmp=new int[9];
    // Start is called before the first frame update
    void Start()
    {
      for(int i=0;i<9;i++)
        {
            scoreDatas[i] = "stage" + (i+1).ToString();
            scores[i] = PlayerPrefs.GetInt(scoreDatas[i]);
        }
      tmp = scores; 
    }

    // Update is called once per frame
    void Update()
    {
        CheckTotalScore();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            for(int i = 0; i < scores.Length;i++)
            {
                PlayerPrefs.SetInt(scoreDatas[i], 0);
                scores[i] = PlayerPrefs.GetInt(scoreDatas[i]);
            }
        }
    }

    public static void CheckTotalScore()
    {
        int tmpScore = ScoreManager.bigEnemyKillCount * 200+ScoreManager.smallEnemyKillCount*100
            +(int)ScoreManager.timer*10+ScoreManager.lvUpCount*2000;
        for(int i=0;i<scores.Length;i++)
        {
            if(StageSelect.selectNumber==i+1)
            {
                if (tmpScore > scores[i])
                {
                    PlayerPrefs.SetInt(scoreDatas[i], tmpScore);
                }
            }
        }
       
    }
    
}Å@Å@Å@
