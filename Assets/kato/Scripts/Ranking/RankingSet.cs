using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingSet : MonoBehaviour
{
    public static string[] ScoreSave = { "1位", "2位", "3位", "4位", "5位",
                                  "6位", "7位", "8位", "9位", "10位" };
    string[] NameSave = {"1位名前","2位名前","3位名前","4位名前",
                                "5位名前","6位名前","7位名前","8位名前",
                                "9位名前","10位名前"};

    static public int[] rankingScore = new int[10];
    static public string[] rankingName = new string[10];

    public static int myScore;
    public static string myName;
    static public bool rankingUpdate;

    [SerializeField] Text[] ScoreText = new Text[10];
    [SerializeField] Text[] NameText = new Text[10];

    void Start()
    {
        getRanking();
        setRanking();
    }

    void Update()
    {
    }

    void getRanking()
    {
        for (int i = 0; i < ScoreSave.Length; i++)//保存したデータを呼び出し
        {
            rankingScore[i] = PlayerPrefs.GetInt(ScoreSave[i]);
            rankingName[i] = PlayerPrefs.GetString(NameSave[i]);
        }
    }

    public void setRanking()
    {
        if (rankingUpdate)
        {
            rankingUpdate = false;
            Debug.Log("ランキング更新");
            for (int i = 0; i < rankingScore.Length; i++)
            {
                if (myScore > rankingScore[i])
                {
                    //ランキング入れ替え
                    //スコア入れ替え
                    var change = rankingScore[i];
                    rankingScore[i] = myScore;
                    myScore = change;

                    //名前入れ替え
                    var changeName = rankingName[i];
                    rankingName[i] = myName;
                    myName = changeName;
                }
            }
        }

        for (int i = 0; i < ScoreSave.Length; i++)
        {
            ScoreText[i].text = String.Format("{00}", rankingScore[i]);//スコアを表示
            NameText[i].text = rankingName[i];

            PlayerPrefs.SetInt(ScoreSave[i], rankingScore[i]);//ランキングを保存
            PlayerPrefs.SetString(NameSave[i], rankingName[i]);
        }
    }

    public static void setScore(int _score, string _name)
    {
        myScore = _score;
        myName = _name;
    }

    public static int getTenScore()
    {
        return PlayerPrefs.GetInt(ScoreSave[9]);
    }
}
