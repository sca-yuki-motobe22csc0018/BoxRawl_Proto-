using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Spine;
using Spine.Unity;
using UnityEngine;

public class BeeEnemy : MonoBehaviour
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

    public GameObject mainObj;
    [SerializeField]
    private string Attack;

    [SerializeField]
    private string Attack2;

    [SerializeField]
    private string Normal;

    private SkeletonAnimation _skeletonAnimation;
    bool anim;
    bool anim2;
    Vector3 scale;

    bool isGround;

    public GameObject pary;

    /// <summary> ゲームオブジェクトに設定されているSkeletonAnimation </summary>
    private SkeletonAnimation skeletonAnimation = default;

    /// <summary> Spineアニメーションを適用するために必要なAnimationState </summary>
    private Spine.AnimationState spineAnimationState = default;


    void Start()
    {
        isGround = false;
        this.transform.parent = null;
        Destroy(mainObj);
        PlayerObj = GameObject.FindWithTag("Player");
        //beeSkin.transform.parent = null;
        isMove = true;
        isAttack = true;
        timer = 0;

        MoveNum = 0;

        PlayerObj = GameObject.FindWithTag("Player");
        anim = false;
        anim2 = false;
        // ゲームオブジェクトのSkeletonAnimationを取得
        skeletonAnimation = GetComponent<SkeletonAnimation>();

        // SkeletonAnimationからAnimationStateを取得
        spineAnimationState = skeletonAnimation.AnimationState;

        _skeletonAnimation = GetComponent<SkeletonAnimation>();

        scale = transform.localScale;

        if (PlayerObj.transform.position.x >= this.transform.position.x)
        {
            scale.x = -0.3f;
            scale.y = 0.3f;
            transform.localScale = scale;
        }
        else
        {
            scale.x = 0.3f;
            scale.y = 0.3f;
            transform.localScale = scale;
        }
    }

    void Update()
    {
        
        if (PlayerMove.PlayerDead)
        {
            return;
        }
        pary.gameObject.transform.position = this.transform.position;
        if (anim2)
        {
            BulletAttack();
        }
        
        timer += Time.deltaTime*2;

        if(timer > 0 && isGround)
        {
            //isMove = false;
            isAttack = false;
            //Move();
            //timer = 4;
        }

        if (timer > 0f && isAttack && !isGround)
        {
            isAttack = false;
            anim = true;
        }

        if (timer > 1f && isGround && isMove)
        {
            isMove = false;
            Move();
        }

        if (timer > 3f && isGround)
        {
            isAttack = true;
            isMove = true;
            timer = 0;
        }

        if (timer > 3f && isMove && !isGround)
        {
            isMove = false;
            Move();
        }

        if (timer > 4)
        {
            isAttack = true;
            isMove = true;
            timer = 0;
        }
        
        if (anim)
        {
            anim = false;
            TrackEntry trackEntry = spineAnimationState.SetAnimation(0, Attack, false);
            trackEntry.Complete += OnSpineComplete;
        }
        
        if (PlayerObj.transform.position.x >= this.transform.position.x)
        {
            scale.x = -0.3f;
            scale.y = 0.3f;
            transform.localScale = scale;
        }
        else
        {
            scale.x = 0.3f;
            scale.y = 0.3f;
            transform.localScale = scale;
        }
    }

    public void BulletAttack()
    {
        BulletPos = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
        BulletDir = PlayerObj.transform.position - this.gameObject.transform.position;
        BulletDir.Normalize();
        Bullet = Instantiate(BulletPrefab, BulletPos, Quaternion.identity);
        BulletRg = Bullet.GetComponent<Rigidbody2D>();
        BulletRg.AddForce(BulletDir * 30000);
        anim2 = false;
    }



    public void Move()
    {
        MoveNum = Random.Range(0, 3);
        if (MoveNum <2)
        {
            if (this.gameObject.transform.position.y > PlayerObj.transform.position.y)
            {
                addPos_Y = -5;
            }
            else
            {
                addPos_Y = 5;
            }

            if (this.gameObject.transform.position.x > PlayerObj.transform.position.x)
            {
                addPos_X = -3;
            }
            else
            {
                addPos_X = 3;
            }
        }
        else if (MoveNum == 2)
        {
            addPos_X = Random.Range(-5, 5);
            addPos_Y = Random.Range(8, 8);
        }

        this.gameObject.transform.DOMove(new Vector2(this.gameObject.transform.position.x + addPos_X,
                                         this.gameObject.transform.position.y + addPos_Y), 0.5f);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Drop"))
        {
            EXPController.EXP += 12.0f * PlayerMove.EXPUP;
            PlayerMove.EXPUP += 1;
            Destroy(this.gameObject);
        }

        

        if (other.gameObject.CompareTag("DestroyObj"))
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")|| collision.gameObject.CompareTag("Wall"))
        {
            isGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall"))
        {
            isGround = false;
        }
    }

    private void OnSpineComplete(TrackEntry trackEntry)
    {
        TrackEntry trackEntry2 = spineAnimationState.SetAnimation(0, Attack, false);
        trackEntry2.Complete += OnSpineComplete2;
    }

    private void OnSpineComplete2(TrackEntry trackEntry)
    {
        anim2 = true;
        spineAnimationState.SetAnimation(0, Normal, true);
    }
}
