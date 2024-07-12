using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
public class PlayerMove : MonoBehaviour
{
    //Rigidbody
    private Rigidbody2D rb;

    //�v���C���[�̌����ڂ̃I�u�W�F�N�g
    public GameObject PlayerSkinObject;

    //�W�����v�ł��邩�m�F���邽�߂̃I�u�W�F�N�g
    public GameObject JumpChecker;

    //�q�b�v�h���b�v�œG��|������̃I�u�W�F�N�g
    public GameObject DropObject;

    //�̗͕\���p�̃I�u�W�F�N�g
    public GameObject[] HpObject;

    //�W�����v�̍����֌W
    public float DefaultJumpForce;
    public static float PlusJumpForce;
    private float JumpForce;

    //�����֌W
    public float DefaultSpeed;
    public static float PlusSpeed;
    private float Speed;

    /*
    //�傫���֌W(�X�e�[�W�̍\���I�Ƀq�b�v�h���b�v�͈̔͋����̂ق����ǂ������ƒ��)
    //[SerializeField] public float DefaultSize;
    //[SerializeField] public float PlusSize;
    //private float Size;
    */

    //�̗͊֌W
    private int DefaultHp=5;
    //[SerializeField] public int PlusHp;
    private int Hp;

    //�󒆂ɋ��邩�̔���
    public static int JumpCount;

    //�ǂɐG��Ă��邩�̔���
   [SerializeField]private bool OnWall;
    bool right;

    //�A���ǃW�����v�����Ȃ��悤�ɂ���
    private bool DoubleWall;

    //�q�b�v�h���b�v�����Ă��邩�̔���
    public static bool Drop;

    //�_���[�W���󂯂Ă��邩�̊m�F
    public static bool blink;
    private bool blinkCheck;
    float blinkCount;

    //�_���[�W���󂯂���̖��G����
    //invincibleTime*0.05�b���G����(invincibleTime==8�Ȃ�0.4�b)
    public int DefaultInvincibleTime;
    public static int PlusInvincibleTime;
    private int InvincibleTime;
    int invincibleTimeCheck;

    //�X�^�[�g����
    bool startRota;
    public Image[] Count;
    public GameObject EnemySpawnner;

    //�p���B����
    public GameObject ParyObject;
    public static bool paryCheck;

    //�_���[�W���o
    public Image damageEffect;

    //���S����
    public static bool PlayerDead;
    bool death;
    bool deathBlink;

    //�o���l�{��
    public static int EXPUP;

    //�V��
    public GameObject Ceiling01;
    //public GameObject Ceiling02;
    //public GameObject Ceiling03;

    //LevelUpWindow���o�����߂�bool
    public static bool LevelUpWindowSet;

    //�t�F�[�h
    bool fadeFlag;

    // Start is called before the first frame update
    void Start()
    {
        if (Ceiling01 != null)
        {
            Ceiling01.SetActive(false);
        }/*
        if (Ceiling02 != null)
        {
            Ceiling02.SetActive(false);
        }
        if (Ceiling03 != null)
        {
            Ceiling03.SetActive(false);
        }*/
        LevelUpWindowSet = false;
        EXPUP = 1;
        PlayerDead = false;
        JumpCount = 0;
        blink = false;
        blinkCheck = false;
        rb = GetComponent<Rigidbody2D>();
        PlayerSkinObject.SetActive(true);
        DropObject.SetActive(false);
        blinkCount = 0;
        invincibleTimeCheck = 0;
        startRota = false;
        if(EnemySpawnner!=null)
        EnemySpawnner.SetActive(false);
        PlusSpeed = 0;
        PlusJumpForce = 0;
        death = false;
        deathBlink = false;
        fadeFlag = false;
        
        //Size = DefaultSize + PlusSize;
        Hp = 5;//DefaultHp + PlusHp;

        for(int i = 0; i < 5; i++)
        {
            HpObject[i].SetActive(false);
        }
        for (int i = 0; i < Hp; i++)
        {
            HpObject[i].SetActive(true);
        }

        ButtonManager.sceneCheck = false;
        ParyObject.SetActive(false);
        paryCheck = false;

        if (SceneManager.GetActiveScene().name == "Main Game")
        {
            if (StageSelect.selectNumber == 1)
            {
                this.transform.position = new Vector3(-70, 35, 0);
            }
            if (StageSelect.selectNumber == 2)
            {
                this.transform.position = new Vector3(0, 35, 0);
            }
            if (StageSelect.selectNumber == 3)
            {
                this.transform.position = new Vector3(70, 35, 0);
            }
        }
        //else
        //{
        //    this.transform.position = new Vector3(0, 0, 0);
        //}



        if (StatusUp.selectTypeNumber == 0)
        {
            PlusJumpForce = 0;
            PlusSpeed=0;
            PlusInvincibleTime=4;
        }
        else if (StatusUp.selectTypeNumber==1)
        {
            PlusJumpForce = -2;
            PlusSpeed = 0;
            PlusInvincibleTime = 20;
        }
        else if (StatusUp.selectTypeNumber==2)
        {
            PlusJumpForce = 0;
            PlusSpeed = 4;
            PlusInvincibleTime = 0;
        }
        else
        {
            PlusJumpForce = 4;
            PlusSpeed = -2;
            PlusInvincibleTime = 4;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(OnWall);

        FadeIO.FadeOut(fadeFlag);

        //�X�e�[�^�X�����
        JumpForce = DefaultJumpForce + PlusJumpForce;
        Speed = DefaultSpeed + PlusSpeed;
        InvincibleTime = DefaultInvincibleTime + PlusInvincibleTime;

        if (EXPUP >= 3)
        {
            EXPUP = 3;
        }

        if (PlayerDead)
        {
            if(EnemySpawnner!=null)
            EnemySpawnner.SetActive(false);
        }
        //�_���[�W���󂯂����̓_��
        if (blink)
        {
            //�_��
            if (blinkCount > 0.05f)
            {
                if (blinkCheck)
                {
                    PlayerSkinObject.SetActive(true);
                    blinkCheck = false;
                    invincibleTimeCheck++;
                }
                else
                {
                    PlayerSkinObject.SetActive(false);
                    blinkCheck = true;
                    invincibleTimeCheck++;
                }
                if (invincibleTimeCheck >= InvincibleTime)
                {
                    blink = false;
                    invincibleTimeCheck = 0;
                }
                blinkCount = 0;
            }
            else
            {
                blinkCount += Time.deltaTime;
            }
        }
        if (!blink)
        {
            if (death&&!deathBlink)
            {
                blink = true;
                deathBlink = true;
                DamageEffect();
                return;
            }
            PlayerSkinObject.SetActive(true);
            blinkCount = 0;
        }

        if (PlayerDead)
        {
            return;
        }
        if (!ButtonManager.sceneCheck)
        {
            if (startRota)
            {
                //�W�����v
                if (Input.GetKeyDown(KeyCode.Space)&&!Drop)
                {
                    if (JumpCount == 0)
                    {
                        //�ǂł̘A���W�����v�h�~
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
                //�ǂ߂荞�ݖh�~
                if (Input.GetKeyDown(KeyCode.A)&&!right)
                {
                    OnWall = false;
                }
                if (Input.GetKeyDown(KeyCode.D)&&right)
                {
                    OnWall = false;
                }


                //���ړ�
                if (Input.GetKey(KeyCode.A))
                {
                    right = true;
                    //�ǂɐG�ꂽ�܂܈ړ����Ȃ�
                    if (!OnWall)
                    {
                        //�q�b�v�h���b�v���Ɉړ����Ȃ�
                        if (!Drop)
                        {
                            PlayerSkin.rota = 1;
                            this.transform.position += new Vector3(-Speed * Time.deltaTime, 0, 0);
                        }
                    }
                }
                //�E�ړ�
                if (Input.GetKey(KeyCode.D))
                {
                    right = false;
                    //�ǂɐG�ꂽ�܂܈ړ����Ȃ�
                    if (!OnWall)
                    {
                        //�q�b�v�h���b�v���Ɉړ����Ȃ�
                        if (!Drop)
                        {
                            PlayerSkin.rota = -1;
                            this.transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
                        }
                    }
                }
                //�q�b�v�h���b�v
                if (Input.GetKeyDown(KeyCode.S))
                {
                    //Debug.Log(ParyController.parySet);
                    //�󒆂ɂ���Ƃ�
                    if (!Drop)
                    {
                        if (JumpCount == 1||ParyController.paryJump)
                        {
                            DropSystem();
                        }
                    }
                    
                }
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
            }
            //�q�b�v�h���b�v�̔���
            if (!Drop)
            {
                DropObject.SetActive(false);
            }
        }

        if (Trigger.EnemyTrigger)
        {
            if (!paryCheck)
            {
                if (!Drop)
                {
                    if (!blink)
                    {
                        if (Hp > 1)
                        {
                            HpObject[Hp - 1].SetActive(false);
                            Hp -= 1;
                            blink = true;
                            CameraMove.damageSway = true;
                            DamageEffect();
                            SEController.damage = true;
                        }
                        else
                        {
                            if(SceneManager.GetActiveScene().name == "Tutorial")
                            {
                                Hp = 5;
                                for (int i = 0; i < 5; i++)
                                {
                                    HpObject[i].SetActive(false);
                                }
                                for (int i = 0; i < Hp; i++)
                                {
                                    HpObject[i].SetActive(true);
                                }
                                return;
                            }
                            if (!death)
                            {
                                death = true;
                                CameraMove.damageSway = true;
                                DamageEffect();
                                SEController.dead = true;
                                Dead();
                                blink = true;
                            }
                            
                        }
                    }
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Ground�ɂӂꂽ�Ƃ�
        if (other.gameObject.CompareTag("Ground"))
        {
            LevelUpWindowSet = true;
            if (!startRota&&SceneManager.GetActiveScene().name!="Menu")
            {
                PlayerSkin.Rota = false;
                StartCount();
                if (Ceiling01 != null)
                {
                    Ceiling01.SetActive(true);
                }/*
                if (Ceiling02 != null)
                {
                    Ceiling02.SetActive(true);
                }
                if (Ceiling03 != null)
                {
                    Ceiling01.SetActive(true);
                }*/

                //Time.timeScale = 0;
            }
            else if(SceneManager.GetActiveScene().name=="Menu")
            {
                PlayerSkin.Rota = false;
                startRota = true;
            }
            DoubleWall = false;
            //�q�b�v�h���b�v�ŐG�ꂽ��J������h�炷
            if (Drop)
            {
                CameraMove.dropSway = true;
                SEController.drop2 = true;
            }
            EXPUP = 1;
        }
        if(other.gameObject.CompareTag("Button"))
        {
            if (Drop)
            {
                CameraMove.dropSway = true;
            }
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            OnWall = true;
            PlayerSkin.rota = 0;
            PlayerSkin.Rota = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //�ǂɐG��Ă����
        if (collision.gameObject.CompareTag("Wall"))
        {
            
            JumpCount = 0;
            ParyObject.SetActive(false);
        }
        //�n�ʂɐG��Ă����
        if (collision.gameObject.CompareTag("Ground")|| collision.gameObject.CompareTag("Button"))
        {
            Time.timeScale = 1.0f;
            Drop = false;
            PlayerSkin.rota = 0;
            PlayerSkin.Rota = false;
            JumpCount = 0;
            ParyObject.SetActive(false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        //�ǂ��痣�ꂽ�Ƃ�
        if (collision.gameObject.CompareTag("Wall"))
        {
            JumpCount = 1;
            if (ParyObject != null)
                ParyObject.SetActive(true);
            PlayerSkin.Rota = true;
            OnWall = false;
            DoubleWall = false;
        }
        //�n�ʂ��痣�ꂽ�Ƃ�
        if (collision.gameObject.CompareTag("Ground")|| collision.gameObject.CompareTag("Button"))
        {
            LevelUpWindowSet = false;
            //Time.timeScale = 0.1f;
            JumpCount = 1;
            if(ParyObject!=null)
            ParyObject.SetActive(true);
            PlayerSkin.Rota = true;
        }
    }
    public void DropSystem()
    {
        var sequence = DOTween.Sequence();
        rb.velocity = new Vector3(0, JumpForce, 0);
        Drop = true;
        SEController.drop1 = true;
        if (PlayerSkin.rota==0)
        {
            PlayerSkin.rota = 1;
        }
        PlayerSkin.rota *= -2;
        sequence.AppendInterval(0.2f);
        sequence.AppendCallback(() => DropSystem2());
    }
    public void DropSystem2()
    {
        DropObject.SetActive(true);
        PlayerSkin.Rota = false;
        PlayerSkin.rota =0;
        rb.velocity = new Vector3(0, -JumpForce *  2, 0);
    }

    public void StartCount()
    {
        if (SceneManager.GetActiveScene().name!="Main Game")
        {
            StartEnd();
            return;
        }
        else
        {
            var sequence = DOTween.Sequence();
            var img3 = Count[3];
            var c3 = img3.color;
            c3.a = 0.0f;
            img3.color = c3;
            var img2 = Count[2];
            var c2 = img2.color;
            c2.a = 0.0f;
            img2.color = c2;
            var img1 = Count[1];
            var c1 = img1.color;
            c1.a = 0.0f;
            img1.color = c1;
            var imgGo = Count[0];
            var cGo = imgGo.color;
            cGo.a = 0.0f;
            imgGo.color = cGo;
            sequence.Append(DOTween.ToAlpha(() => img3.color, color => img3.color = color, 1, 0.25f));
            sequence.Append(DOTween.ToAlpha(() => img3.color, color => img3.color = color, 0, 0.25f));
            sequence.Append(DOTween.ToAlpha(() => img2.color, color => img2.color = color, 1, 0.25f));
            sequence.Append(DOTween.ToAlpha(() => img2.color, color => img2.color = color, 0, 0.25f));
            sequence.Append(DOTween.ToAlpha(() => img1.color, color => img1.color = color, 1, 0.25f));
            sequence.Append(DOTween.ToAlpha(() => img1.color, color => img1.color = color, 0, 0.25f));
            sequence.Append(DOTween.ToAlpha(() => imgGo.color, color => imgGo.color = color, 1, 0.25f));
            sequence.Append(DOTween.ToAlpha(() => imgGo.color, color => imgGo.color = color, 0, 0.25f));
            sequence.AppendCallback(() => StartEnd());
        }
       
    }

    public void StartEnd()
    {
        startRota = true;
        if(EnemySpawnner!=null)
        EnemySpawnner.SetActive(true);
    }

    public void DamageEffect()
    {
        var sequence = DOTween.Sequence();
        var img = damageEffect;
        var color = damageEffect.color;
        color.a = 0;
        for (int i=5/*DefaultHp+PlusHp*/;i>Hp;i--)
        {
            sequence.Append(DOTween.ToAlpha(() => img.color, color => img.color = color, 0.8f, 0.1f));
            sequence.Append(DOTween.ToAlpha(() => img.color, color => img.color = color, 0, 0.1f));
        }
    }

    public void Dead()
    {
        var sequence = DOTween.Sequence();
        //PlayerSkinObject.SetActive(false);
        HpObject[0].SetActive(false);
        Hp = 0;
        PlayerDead = true;
        if(EnemySpawnner!=null)
        EnemySpawnner.SetActive(false);
        Destroy(rb);
        PlayerSkin.Rota = false;
        fadeFlag = true;
        sequence.AppendInterval(3.0f);
        sequence.AppendCallback(() => SceneChange());
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("Result");
    }
}
