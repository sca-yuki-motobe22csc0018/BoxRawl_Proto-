using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public static int bigEnemyKillCount;
    public static int smallEnemyKillCount;
    public static int lvUpCount;
    public static float timer;
    [SerializeField] private GameObject enemySpanwer;
    
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
    }
}
