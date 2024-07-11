using Spine.Unity;
using Spine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlogEnemy : MonoBehaviour
{
    [SerializeField]
    private string JumpA;

    [SerializeField]
    private string JumpB;

    [SerializeField]
    private string JumpC;

    private SkeletonAnimation _skeletonAnimation;

    /// <summary> �Q�[���I�u�W�F�N�g�ɐݒ肳��Ă���SkeletonAnimation </summary>
    private SkeletonAnimation skeletonAnimation = default;

    /// <summary> Spine�A�j���[�V������K�p���邽�߂ɕK�v��AnimationState </summary>
    private Spine.AnimationState spineAnimationState = default;


    Rigidbody2D rb;

    Vector3 scale;

    bool right;
    int dir;

    bool Jump;
    bool wallSpeed;

    public float speed;
    float defaultSpeed;


    bool OnGround;

    // Start is called before the first frame update
    void Start()
    {

        // �Q�[���I�u�W�F�N�g��SkeletonAnimation���擾
        skeletonAnimation = GetComponent<SkeletonAnimation>();

        // SkeletonAnimation����AnimationState���擾
        spineAnimationState = skeletonAnimation.AnimationState;

        _skeletonAnimation = GetComponent<SkeletonAnimation>();

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

        scale = transform.localScale;
        int speedRand = Random.Range(2, 6);
        defaultSpeed = speed + speedRand;
        wallSpeed = false;

        OnGround = false;
        this.gameObject.tag = "Untagged";
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.PlayerDead)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }
        if (!OnGround)
        {
            transform.position += new Vector3(speed * dir * Time.deltaTime, 0, 0);
        }

        if (right)
        {
            dir = 1;
            scale.x = 0.3f;
            transform.localScale = scale;
        }
        else
        {
            dir = -1;
            scale.x = -0.3f;
            transform.localScale = scale;
        }
        if (Jump)
        {
            rb.velocity = new Vector3(0, 20, 0);
            Jump = false;
            PlayJumpAnimationA();
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

        if (other.gameObject.CompareTag("Ground"))
        {
            this.gameObject.tag = "Enemy";
            OnGround = true;
            wallSpeed = false;
            PlayJumpAnimationC();
            if (speed != defaultSpeed)
            {
                speed = defaultSpeed;
            }
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            if (wallSpeed == false)
            {
                int speedRand = Random.Range(2, 5);
                speed += speedRand;
                
                wallSpeed = true;
            }

            rb.velocity = new Vector3(0, 20, 0);

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

    private void OnCollisionExit2D(Collision2D other)
    {
        if (PlayerMove.PlayerDead)
        {
            return;
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            OnGround = false;
        }
    }

    private void PlayJumpAnimationA()
    {
        TrackEntry trackEntry = spineAnimationState.SetAnimation(0, JumpA, false);

        trackEntry.Complete += OnSpineComplete;
    }
    private void PlayJumpAnimationC()
    {
        TrackEntry trackEntry = spineAnimationState.SetAnimation(0, JumpC, false);

        trackEntry.Complete += OnSpineComplete2;
    }

    private void OnSpineComplete(TrackEntry trackEntry)
    {
        // �A�j���[�V�����������ɍs���������L��
        spineAnimationState.SetAnimation(0, JumpB, true);
    }

    private void OnSpineComplete2(TrackEntry trackEntry)
    {
        Jump = true;
    }
}
