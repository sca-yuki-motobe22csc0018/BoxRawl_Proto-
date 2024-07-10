using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;

public class EnemyAlpha00 : MonoBehaviour
{
    Rigidbody2D rb;
    bool wallSpeed;

    public float speed;
    float defaultSpeed;
    bool right;
    int dir;

    public int EnemyCheck;
    bool Jump;

    Vector3 scale;
    /*
    [SerializeField]
    private string JumpA;

    [SerializeField]
    private string JumpB;

    [SerializeField]
    private string JumpC;

    private SkeletonAnimation _skeletonAnimation;

    /// <summary> ゲームオブジェクトに設定されているSkeletonAnimation </summary>
    private SkeletonAnimation skeletonAnimation = default;

    /// <summary> Spineアニメーションを適用するために必要なAnimationState </summary>
    private Spine.AnimationState spineAnimationState = default;
    */
    // Start is called before the first frame update
    void Start()
    {
        /*
        // ゲームオブジェクトのSkeletonAnimationを取得
        skeletonAnimation = GetComponent<SkeletonAnimation>();

        // SkeletonAnimationからAnimationStateを取得
        spineAnimationState = skeletonAnimation.AnimationState;

        _skeletonAnimation = GetComponent<SkeletonAnimation>();
        */
        wallSpeed = false;
        rb = GetComponent<Rigidbody2D>();
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            right = false;
            dir = 1;
        }
        else
        {
            right = true;
            dir = -1;
        }
        Jump = false;
        float speedrand = Random.Range(0, 2.0f);
        defaultSpeed = speed + speedrand;
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.PlayerDead)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }

        transform.position += new Vector3(speed*dir*Time.deltaTime,0,0);

        if (right)
        {
            dir = 1;
            scale.x = 1;
            transform.localScale = scale;
        }
        else
        {
            dir = -1;
            scale.x = -1;
            transform.localScale = scale;
        }
        if (Jump)
        {
            rb.velocity = new Vector3(0, 13, 0);
            Jump = false;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {

        if (PlayerMove.PlayerDead)
        {
            return;
        }
        
        if (other.gameObject.CompareTag("Drop"))
        {
            EXPController.EXP += 5.0f * PlayerMove.EXPUP;
            PlayerMove.EXPUP += 1;
            ScoreManager.bigEnemyKillCount++;
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (PlayerMove.PlayerDead)
        {
            return;
        }
        

        if (other.gameObject.CompareTag("Wall"))
        {
            if (EnemyCheck == 1)
            {
                if (wallSpeed == false)
                {
                    speed += 3;
                    rb.velocity = new Vector3(0, 20, 0);
                    wallSpeed = true;
                }
            }
            if (right == false)
            {
                right = true;
            }
            else
            {
                right = false;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            
            if (EnemyCheck == 1)
            {
                Jump = true;
            }

            if (EnemyCheck == 2)
            {
                Jump = true;
                int random = Random.Range(0, 3);
                if (random == 0)
                {
                    if (right)
                    {
                        right = false;
                    }
                    else
                    {
                        right = true;
                    }
                }
            }
            if (speed != defaultSpeed)
            {
                speed = defaultSpeed;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (PlayerMove.PlayerDead)
        {
            return;
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            scale.x *= -1;
            transform.localScale = scale;
        }
        if (other.gameObject.CompareTag("Ground"))
        {/*
            if (EnemyCheck == 1)
            {
                PlayJumpAnimationA();
            }
            */
        }
    }
    /*
    private void PlayJumpAnimationA()
    {
        spineAnimationState.SetAnimation(0, JumpA, true);
    }
    private void PlayJumpAnimationB()
    {
        spineAnimationState.SetAnimation(0, JumpB, true);
    }
    private void PlayJumpAnimationC()
    {
        spineAnimationState.SetAnimation(0, JumpC, true);
    }
    */
}
