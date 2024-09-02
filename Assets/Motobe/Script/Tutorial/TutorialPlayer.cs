using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class TutorialPlayer : MonoBehaviour
{
    //Rigidbody
    private Rigidbody2D rb;

    //ジャンプできるか確認するためのオブジェクト
    public GameObject JumpChecker;

    //ヒップドロップで敵を倒す判定のオブジェクト
    public GameObject DropObject;

    //ジャンプの高さ関係
    public float DefaultJumpForce;
    public static float PlusJumpForce;
    private float JumpForce;

    //速さ関係
    public float DefaultSpeed;
    public static float PlusSpeed;
    private float Speed;
    
    //空中に居るかの判定
    public static int JumpCount;

    //壁に触れているかの判定
    //[SerializeField] private bool OnWall;
    bool right;

    //連続壁ジャンプをしないようにする
    private bool DoubleWall;

    //ヒップドロップをしているかの判定
    public static bool Drop;

    //ダメージを受けているかの確認
    public static bool blink;
    //private bool blinkCheck;
    //float blinkCount;
    /*
    //パリィ処理
    public GameObject ParyObject;
    public static bool paryCheck;
    */

    //Skin
    public static bool Rota;
    public static int rota;
    public float speed;
    //プレイヤーの見た目のオブジェクト
    public GameObject PlayerSkinObject;

    int dir;
    public int playerNumber;

    // Start is called before the first frame update
    void Start()
    {
        JumpCount = 0;
        blink = false;
        //blinkCheck = false;
        rb = GetComponent<Rigidbody2D>();
        PlayerSkinObject.SetActive(true);
        DropObject.SetActive(false);
        //blinkCount = 0;
        PlusSpeed = 0;
        PlusJumpForce = 0;
        dir=-1;

        ButtonManager.sceneCheck = false;
        /*
        ParyObject.SetActive(false);
        paryCheck = false;
        */

        //Skin
        rota = 1;
        Rota = true;
        speed = 750f;
    }

    // Update is called once per frame
    void Update()
    {
        //ステータスを入力
        JumpForce = DefaultJumpForce + PlusJumpForce;
        Speed = DefaultSpeed + PlusSpeed;
        /*
        //ジャンプ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (JumpCount == 0)
            {
                //壁での連続ジャンプ防止
                if (OnWall)
                {
                    if (!DoubleWall)
                    {
                        rb.velocity = new Vector3(0, JumpForce, 0);
                        DoubleWall = true;
                        SEController.jump = true;
                    }
                }
                else
                {
                    rb.velocity = new Vector3(0, JumpForce, 0);
                    SEController.jump = true;
                }
            }
        }
        */
        //壁めり込み防止
        if (!right)
        {
            //OnWall = false;
        }
        if (right)
        {
            //OnWall = false;
        }

        if (playerNumber == 0)
        {
            this.transform.position += new Vector3(dir * Speed * Time.deltaTime, 0, 0);
        }
            
        /*
        //ヒップドロップ
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Debug.Log(ParyController.parySet);
            //空中にいるとき
            if (!Drop)
            {
                if (JumpCount == 1 || ParyController.paryJump)
                {
                    DropSystem();
                }
            }

        }
        */

        //ジャンプ可能か確認用オブジェクトの表示非表示
        if (JumpCount == 0)
        {
            if (!DoubleWall)
            {
                JumpChecker.SetActive(true);
            }
            else
            {
                JumpChecker.SetActive(false);
            }
        }
        else
        {
            JumpChecker.SetActive(false);
        }
        //ヒップドロップの判定
        if (!Drop)
        {
            DropObject.SetActive(false);
        }

        //Skin
        if (Rota)
        {
            PlayerSkinObject.transform.Rotate(0, 0, speed * rota * Time.deltaTime);
        }
        if (!Rota)
        {
            PlayerSkinObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Groundにふれたとき
        if (other.gameObject.CompareTag("Ground"))
        {
            DoubleWall = false;

            if (playerNumber == 0)
            {
                if (dir == -1)
                {
                    rb.velocity = new Vector3(0, JumpForce, 0);
                }
                dir *= -1;
            }
            if (playerNumber == 1)
            {
                if (dir == -1)
                {
                    rb.velocity = new Vector3(0, JumpForce, 0);
                }
                dir *= -1;
            }
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            //OnWall = true;
            rota=0;
            Rota = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //壁に触れている間
        if (collision.gameObject.CompareTag("Wall"))
        {
            JumpCount = 0;
            //ParyObject.SetActive(false);
        }
        //地面に触れている間
        if (collision.gameObject.CompareTag("Ground"))
        {
            Time.timeScale = 1.0f;
            Drop = false;
            //rota = 0;
            Rota = false;
            JumpCount = 0;
            //ParyObject.SetActive(false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //壁から離れたとき
        if (collision.gameObject.CompareTag("Wall"))
        {
            JumpCount = 1;
            //if (ParyObject != null)
            //    ParyObject.SetActive(true);
            Rota = true;
            //OnWall = false;
            DoubleWall = false;
        }
        //地面から離れたとき
        if (collision.gameObject.CompareTag("Ground"))
        {
            JumpCount = 1;
            //if (ParyObject != null)
            //    ParyObject.SetActive(true);
            rota *= -1;
            Rota = true;
        }
    }

    public void DropSystem()
    {
        var sequence = DOTween.Sequence();
        rb.velocity = new Vector3(0, JumpForce, 0);
        Drop = true;
        SEController.drop1 = true;
        if (rota == 0)
        {
            rota = 1;
        }
        rota *= -2;
        sequence.AppendInterval(0.2f);
        sequence.AppendCallback(() => DropSystem2());
    }
    public void DropSystem2()
    {
        DropObject.SetActive(true);
        Rota = false;
        rota = 0;
        rb.velocity = new Vector3(0, -JumpForce * 2, 0);
    }
}
