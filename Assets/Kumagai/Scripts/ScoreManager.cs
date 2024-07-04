using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public static int bigEnemyKillCount;
    public static int smallEnemyKillCount;
    public static int lvUpCount;
    public static float timer;
    [SerializeField] private GameObject enemySpanwer;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        bigEnemyKillCount = 0;
        smallEnemyKillCount = 0;
        lvUpCount = 0;
        timer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if(!PlayerMove.PlayerDead&&SceneManager.GetActiveScene().name=="Main Game"&&enemySpanwer.activeSelf)
        {
            timer += Time.deltaTime;
        }
        //scoreText.text = (bigEnemyKillCount * 200 + smallEnemyKillCount * 100 + lvUpCount * 2000 + (int)timer * 10).ToString();
        int tmpTimer = (int)(timer*100);
        timeText.text =timer.ToString("f2");
        //Debug.Log(timer.ToString("f2"));
    }
}
