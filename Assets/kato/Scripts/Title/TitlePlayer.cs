using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePlayer : MonoBehaviour
{
    public static bool isJump;
    [SerializeField] GameObject EnemyObj;

    Rigidbody2D rg;
    int moveNum;

    void Start()
    {
        rg = this.gameObject.GetComponent<Rigidbody2D>();
        moveNum = 0;
    }

    void Update()
    {
        if (EnemyObj.transform.position.x - this.gameObject.transform.position.x < 2 && !isJump)
        {
            rg.velocity = new Vector2(0, 8.0f) * 1;
            isJump = true;
            //jumpObj.SetActive(true);
            moveNum = Random.Range(0, 2);

            if (moveNum == 1)
            {
                StartCoroutine(playerAttack());
            }
        }
    }

    /// <summary>
    /// タイトルプレイヤー演出
    /// </summary>
    /// <returns></returns>
    IEnumerator playerAttack()
    {
        yield return new WaitForSeconds(0.4f);
        rg.gravityScale = 20.0f;
        //dropObj.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        rg.gravityScale = 1.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            PlayerSkin.Rota = false;
        }
    }

}
