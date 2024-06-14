using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    int totalScore;
    float countScore;
    bool isCountUp;
    int tenScore;
    [SerializeField] Text scoreText;

    string myName;
    [SerializeField] InputField nameField;
    [SerializeField] GameObject nameCanvas;

    void Start()
    {
        nameCanvas.SetActive(false);
        countScore = 0;
        totalScore = -1;
        isCountUp = true;

        myName = null;

        tenScore = RankingSet.getTenScore();
        Debug.Log(tenScore);
    }


    void Update()
    {
        if (isCountUp)
        {
            scoreCountUp();
        }
        else if(!isCountUp)
        {
            if(totalScore > tenScore)
            {
                if (Input.GetKeyUp(KeyCode.A))
                {
                    nameCanvas.SetActive(true);
                }
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.A))
                {
                    SceneManager.LoadScene("Menu");
                }
            }
        }

        if(Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void scoreCountUp()
    {
        if (countScore < totalScore)
        {
            countScore += (totalScore * Time.deltaTime) / 7;
            scoreText.text = countScore.ToString("f0");
        }
        else if(countScore > totalScore) 
        {
            countScore = totalScore;
            scoreText.text = totalScore.ToString("f0");
            isCountUp=false;
        }
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
}
