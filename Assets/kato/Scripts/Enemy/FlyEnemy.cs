using DG.Tweening;
using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    public GameObject PlayerObj;

    float timer;

    bool isMove;
    bool isAttack;

    public static bool attack;

    //�e�֌W
    public GameObject BulletPrefab;
    GameObject Bullet;
    Rigidbody2D BulletRg;
    Vector2 BulletDir;  //�e���΂�����
    Vector2 BulletPos;

    //�����֌W
    int addPos_X;
    int addPos_Y;

    int MoveNum;

    //�X�L��
    public GameObject beeSkin;
    SpriteRenderer skinSprite;
    bool left = true;
    bool right = false;


    void Start()
    {
        

        skinSprite = beeSkin.GetComponent<SpriteRenderer>();
        PlayerObj = GameObject.FindWithTag("Player");
        beeSkin.transform.parent = null;
        isMove = true;
        isAttack = true;
        timer = 0;

        MoveNum = 0;
    }

    void Update()
    {
        if (PlayerMove.PlayerDead)
        {
            return;
        }
        if (attack)
        {
            attack = false;
        }

        timer += Time.deltaTime;

        if(timer > 1 && isAttack)
        {
            isAttack = false;
            BulletAttack();
        }

        if(timer > 2 && isMove) 
        {
            isMove = false ;
            Move();
        }

        if(timer > 4) 
        {
            isAttack = true;
            isMove = true ;
            timer = 0;
        }

    }

    public void BulletAttack()
    {
        BulletPos = new Vector2(this.gameObject.transform.position.x,
                                this.gameObject.transform.position.y);

        BulletDir = PlayerObj.transform.position - this.gameObject.transform.position;
        BulletDir.Normalize();
        Bullet = Instantiate(BulletPrefab,BulletPos,Quaternion.identity);
        BulletRg = Bullet.GetComponent<Rigidbody2D>();
        BeeSkin.anim = true;
        BulletRg.AddForce(BulletDir * 15000);
    }

    

    public void Move()
    {
        MoveNum = Random.Range(1, 3);

        if(MoveNum == 1)
        {
            if (this.gameObject.transform.position.x - PlayerObj.transform.position.x > 0)
            {
                addPos_X = -2;
            }
            else
            {
                addPos_X = 2;
            }

            if (this.gameObject.transform.position.y > 10)
            {
                addPos_Y = -2;
            }
            else if (this.gameObject.transform.position.y > 0)
            {
                addPos_Y = Random.Range(-2, 3);
            }
            else if (this.gameObject.transform.position.y < 0)
            {
                addPos_Y = 2;
            }
        }
        else if(MoveNum == 2)
        {
            addPos_X = Random.Range(-2, 3);
            addPos_Y = Random.Range(1, 3);
        }

        this.gameObject.transform.DOMove(new Vector2( this.gameObject.transform.position.x + addPos_X,
                                         this.gameObject.transform.position.y + addPos_Y), 1.0f);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Drop"))
        {
            EXPController.EXP += 8.0f * PlayerMove.EXPUP;
            PlayerMove.EXPUP += 1;
            Destroy(beeSkin.gameObject);
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("DestroyObj"))
        {
            Destroy(this.gameObject);
        }
    }
    /*
    void lookDirection()   //�v���C���[�̂ق�������
    {
        if (this.gameObject.transform.position.x > PlayerObj.transform.position.x)
        {

        }
        else
        {
            skinSprite.flipX = left;
        }
    }
    */
}
