using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayer02 : MonoBehaviour
{
    //Rigidbody
    private Rigidbody2D rb;

    //�W�����v�ł��邩�m�F���邽�߂̃I�u�W�F�N�g
    public GameObject JumpChecker;

    //�q�b�v�h���b�v�œG��|������̃I�u�W�F�N�g
    public GameObject DropObject;

    //�W�����v�̍����֌W
    public float DefaultJumpForce;
    public static float PlusJumpForce;
    private float JumpForce;

    //�����֌W
    public float DefaultSpeed;
    public static float PlusSpeed;
    private float Speed;

    //�󒆂ɋ��邩�̔���
    public static int JumpCount;

    //�ǂɐG��Ă��邩�̔���
    [SerializeField] private bool OnWall;
    bool right;

    //�A���ǃW�����v�����Ȃ��悤�ɂ���
    private bool DoubleWall;

    //�q�b�v�h���b�v�����Ă��邩�̔���
    public static bool Drop;

    //�_���[�W���󂯂Ă��邩�̊m�F
    public static bool blink;
    private bool blinkCheck;
    float blinkCount;

    //Skin
    public static bool Rota;
    public static int rota;
    public float speed;
    //�v���C���[�̌����ڂ̃I�u�W�F�N�g
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
        //�X�e�[�^�X�����
        JumpForce = DefaultJumpForce + PlusJumpForce;
        //Speed = DefaultSpeed + PlusSpeed;
        if (OnWall)
        {
            JumpChecker.SetActive(true);
        }
        this.transform.position += new Vector3(dir * Speed * Time.deltaTime, 0, 0);
        //�W�����v�\���m�F�p�I�u�W�F�N�g�̕\����\��
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
        //�q�b�v�h���b�v�̔���
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
        //Ground�ɂӂꂽ�Ƃ�
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
        //�ǂɐG��Ă����
        if (collision.gameObject.CompareTag("Wall"))
        {
            JumpCount = 0;
            OnWall = true;
        }
        //�n�ʂɐG��Ă����
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
        //�ǂ��痣�ꂽ�Ƃ�
        if (collision.gameObject.CompareTag("Wall"))
        {
            JumpCount = 1;
            Rota = true;
            OnWall = false;
            DoubleWall = false;
        }
        //�n�ʂ��痣�ꂽ�Ƃ�
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
