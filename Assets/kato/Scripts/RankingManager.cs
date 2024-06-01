using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RankingManager : MonoBehaviour
{
    public string[] ScoreSave = { "1��", "2��", "3��", "4��", "5��",
                                  "6��", "7��", "8��", "9��", "10��" };
    public string[] NameSave = {"1�ʖ��O","2�ʖ��O","3�ʖ��O","4�ʖ��O",
                                "5�ʖ��O","6�ʖ��O","7�ʖ��O","8�ʖ��O",
                                "9�ʖ��O","10�ʖ��O"};

    static public int[] rankingScore = new int[10];
    public string[] rankingName = new string[10];

    public static int myScore;
    public static string myName;
    static public bool rankingUpdate;

    [SerializeField] Text[] ScoreText = new Text[10];
    [SerializeField] Text[] NameText = new Text[10];

    // Start is called before the first frame update
    void Start()
    {
        rankingUpdate = false;
        myScore = 0;
        getRanking();

    }

    // Update is called once per frame
    void Update()
    {
        setRanking();
    }

    void getRanking()
    {
        for (int i = 0; i < ScoreSave.Length; i++)//�ۑ������f�[�^���Ăяo��
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
            Debug.Log("�����L���O�X�V");
            for (int i = 0; i < rankingScore.Length; i++)
            {
                if (myScore > rankingScore[i])
                {
                    //�����L���O����ւ�
                    //�X�R�A����ւ�
                    var change = rankingScore[i];
                    rankingScore[i] = myScore;
                    myScore = change;

                    //���O����ւ�
                    var changeName = rankingName[i];
                    rankingName[i] = myName;
                    myName = changeName;
                }
            }

            for (int i = 0; i < ScoreSave.Length; i++)
            {
                ScoreText[i].text = String.Format("{00}", rankingScore[i]);//�X�R�A��\��
                NameText[i].text = rankingName[i];

                PlayerPrefs.SetInt(ScoreSave[i], rankingScore[i]);//�����L���O��ۑ�
                PlayerPrefs.SetString(NameSave[i], rankingName[i]);
            }

        }

        
    }

    public void Retray()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void goMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
