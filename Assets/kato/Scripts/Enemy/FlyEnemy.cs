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

    //弾関係
    public GameObject BulletPrefab;
    GameObject Bullet;
    Rigidbody2D BulletRg;
    Vector2 BulletDir;  //弾を飛ばす方向
    Vector2 BulletPos;

    //動き関係
    int addPos_X;
    int addPos_Y;

    int MoveNum;

    //スキン
    public GameObject beeSkin;


    void Start()
    {
        PlayerObj = GameObject.FindWithTag("Player");
        beeSkin.transform.parent = null;
        isMove = true;
        isAttack = true;
        timer = 0;

        MoveNum = 0;
    }

    void Update()
    {
        /*
        if (PlayerMove.PlayerDead)
        {
            return;
        }
        if (BeeSkin.anim2)
        {
            BulletAttack();
            
        }
        */
        timer += Time.deltaTime;

        if(timer > 1 && isAttack)
        {
            isAttack = false;
            BulletAttack();
            //BeeSkin.anim = true;
            //
        }

        if(timer > 3 && isMove) 
        {
            isMove = false ;
            Move();
        }

        if(timer > 5) 
        {
            isAttack = true;
            isMove = true ;
            timer = 0;
        }

    }

    public void BulletAttack()
    {
        BulletPos = new Vector2(this.gameObject.transform.position.x,this.gameObject.transform.position.y);
        BulletDir = PlayerObj.transform.position - this.gameObject.transform.position;
        BulletDir.Normalize();
        Bullet = Instantiate(BulletPrefab,BulletPos,Quaternion.identity);
        BulletRg = Bullet.GetComponent<Rigidbody2D>();
        BulletRg.AddForce(BulletDir * 25000);
        //BeeSkin.anim2 = false;
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
    void lookDirection()   //プレイヤーのほうを見る
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
