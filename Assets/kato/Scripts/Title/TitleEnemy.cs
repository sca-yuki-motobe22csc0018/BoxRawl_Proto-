using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TitleEnemy : MonoBehaviour
{
    Rigidbody2D EnemyRg;
    Vector3 enemyStartPos;
    int EnemyNum = 0;

    public GameObject playerObj;

    bool isUp;

    [SerializeField] GameObject EnemyObj;
    SpriteRenderer enemySpr;
    [SerializeField] Sprite[] enemySprite;

    [SerializeField] GameObject[] enemySkin;

    int moveSpeed = 1;
    void Start()
    {
        enemyStartPos = this.gameObject.transform.position;
        EnemyRg = this.gameObject.GetComponent<Rigidbody2D>();
        EnemyNum = 0;

        isUp = true;

        //enemySpr = EnemyObj.GetComponent<SpriteRenderer>();
        enemySkin[0].SetActive(true);
        enemySkin[1].SetActive(false);

        moveSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        eMove();
    }

    /// <summary>
    /// タイトルプレイヤーに当たった時の処理
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            this.gameObject.transform.position = new Vector3(-12.0f, 0f, 0f);
        }
    }

    /// <summary>
    /// 敵の動き
    /// </summary>
    void eMove()
    {
        if (TitleManager.isStart)
        {
            moveSpeed = 2;
        }
        this.gameObject.transform.position += new Vector3(-4.0f * moveSpeed, 0, 0) * Time.deltaTime;

        if (this.gameObject.transform.position.x < -11
            && !TitleManager.isStart)
        {
            TitlePlayer.isJump = false;
            EnemyNum = Random.Range(0, 2);
            if (EnemyNum == 0)　//牛
            {
                EnemyRg.velocity = Vector2.zero;
                EnemyRg.angularVelocity = 0.0f;
                EnemyRg.gravityScale = 0.0f;
                this.gameObject.transform.position = enemyStartPos;

                //enemySpr.sprite = enemySprite[EnemyNum];
                enemySkin[0].SetActive(true);
                enemySkin[1].SetActive(false);
            }
            else if (EnemyNum == 1) //モモンガ
            {
                isUp = true;
                EnemyRg.velocity = Vector2.zero;
                EnemyRg.angularVelocity = 0.0f;
                EnemyRg.gravityScale = 0.12f;
                this.gameObject.transform.position = new Vector3(enemyStartPos.x, 4.3f, enemyStartPos.z);

                //enemySpr.sprite = enemySprite[EnemyNum];
                enemySkin[0].SetActive(false);
                enemySkin[1].SetActive(true);
            }
        }

        //上に飛んでいく
        if (this.gameObject.transform.position.x - playerObj.transform.position.x < 2 && isUp)
        {
            if (EnemyNum == 1)
            {
                isUp = false;
                EnemyRg.velocity = Vector2.zero;
                EnemyRg.angularVelocity = 0.0f;
                EnemyRg.gravityScale = -0.11f;

                Debug.Log("上に行く");
            }
        }
    }
}
