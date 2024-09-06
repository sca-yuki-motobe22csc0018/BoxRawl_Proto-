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

    public GameObject pary;

    /// <summary> �Q�[���I�u�W�F�N�g�ɐݒ肳��Ă���SkeletonAnimation </summary>
    private SkeletonAnimation skeletonAnimation = default;

    /// <summary> Spine�A�j���[�V������K�p���邽�߂ɕK�v��AnimationState </summary>
    private Spine.AnimationState spineAnimationState = default;


    void Start()
    {
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
        // �Q�[���I�u�W�F�N�g��SkeletonAnimation���擾
        skeletonAnimation = GetComponent<SkeletonAnimation>();

        // SkeletonAnimation����AnimationState���擾
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

        if (timer > 1 && isAttack)
        {
            isAttack = false;
            anim = true;
        }

        if (timer > 3 && isMove)
        {
            isMove = false;
            Move();
        }

        if (timer > 11)
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
        MoveNum = Random.Range(1, 3);

        if (MoveNum == 1)
        {
            if (this.gameObject.transform.position.x - PlayerObj.transform.position.x > 0)
            {
                addPos_X = -5;
            }
            else
            {
                addPos_X = 5;
            }

            if (this.gameObject.transform.position.y > 10)
            {
                addPos_Y = -8;
            }
            else if (this.gameObject.transform.position.y > 0)
            {
                addPos_Y = Random.Range(-8, 8);
            }
            else if (this.gameObject.transform.position.y < 0)
            {
                addPos_Y = 5;
            }
        }
        else if (MoveNum == 2)
        {
            addPos_X = Random.Range(-8, 8);
            addPos_Y = Random.Range(0, 5);
        }

        this.gameObject.transform.DOMove(new Vector2(this.gameObject.transform.position.x + addPos_X,
                                         this.gameObject.transform.position.y + addPos_Y), 0.5f);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Drop"))
        {
            EXPController.EXP += 8.0f * PlayerMove.EXPUP;
            PlayerMove.EXPUP += 1;
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("DestroyObj"))
        {
            Destroy(this.gameObject);
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