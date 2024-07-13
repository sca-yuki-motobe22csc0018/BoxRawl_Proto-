using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayer02 : MonoBehaviour
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
    [SerializeField] private bool OnWall;
    bool right;

    //連続壁ジャンプをしないようにする
    private bool DoubleWall;

    //ヒップドロップをしているかの判定
    public static bool Drop;

    //ダメージを受けているかの確認
    public static bool blink;
    private bool blinkCheck;
    float blinkCount;

    //Skin
    public static bool Rota;
    public static int rota;
    public float speed;
    //プレイヤーの見た目のオブジェクト
    public GameObject PlayerSkinObject;

    int dir;
    public int playerNumber;
    bool Check;

    // Start is called before the first frame update
    void Start()
    {
        JumpCount = 0;
        blink = false;
        blinkCheck = false;
        rb = GetComponent<Rigidbody2D>();
        PlayerSkinObject.SetActive(true);
        DropObject.SetActive(false);
        blinkCount = 0;
        PlusSpeed = 0;
        PlusJumpForce = 0;
        dir = -1;
        Check = true;
        ButtonManager.sceneCheck = false;

        //Skin
        rota = 1;
        Rota = true;
        speed = 750f;
        Speed = DefaultSpeed + PlusSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //ステータスを入力
        JumpForce = DefaultJumpForce + PlusJumpForce;
        //Speed = DefaultSpeed + PlusSpeed;
        if (OnWall)
        {
            JumpChecker.SetActive(true);
        }
        this.transform.position += new Vector3(dir * Speed * Time.deltaTime, 0, 0);
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
            if (!Check)
            {
                //rb.velocity = new Vector3(0, JumpForce, 0);
            }
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            rb.velocity = new Vector3(0, JumpForce, 0);
            OnWall = true;
            rota *=-1;
            dir *=-1;
            Rota = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //壁に触れている間
        if (collision.gameObject.CompareTag("Wall"))
        {
            JumpCount = 0;
            OnWall = true;
        }
        //地面に触れている間
        if (collision.gameObject.CompareTag("Ground"))
        {
            Time.timeScale = 1.0f;
            Drop = false;
            Rota = false;
            JumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //壁から離れたとき
        if (collision.gameObject.CompareTag("Wall"))
        {
            JumpCount = 1;
            Rota = true;
            OnWall = false;
            DoubleWall = false;
        }
        //地面から離れたとき
        if (collision.gameObject.CompareTag("Ground"))
        {
            JumpCount = 1;
            rota *= -1;
            Rota = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            dir *= -1;
            if (rota == 0)
            {
                rota = -1;
            }
            Speed = 5;
            if (Check)
            {
                rb.velocity = new Vector3(0, JumpForce, 0);
                Speed = 10;
                rota = 1;
            }
            Check = !Check;
        }
    }
}
