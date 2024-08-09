using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;

public class MoleEnemy : MonoBehaviour
{
    GameObject player;

    [SerializeField] ParticleSystem smokePrefab;
    ParticleSystem smoke;

    Rigidbody2D rg;
    float timer;

    //Vector3 smokePos;
    Vector3 GroundPos;

    bool onGroun;

    int addPos_X;

    [SerializeField]
    private string Jump;

    [SerializeField]
    private string Normal;

    public GameObject Pary;

    private SkeletonAnimation _skeletonAnimation;

    /// <summary> ゲームオブジェクトに設定されているSkeletonAnimation </summary>
    private SkeletonAnimation skeletonAnimation = default;

    /// <summary> Spineアニメーションを適用するために必要なAnimationState </summary>
    private Spine.AnimationState spineAnimationState = default;

    Vector3 scale;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rg = this.gameObject.GetComponent<Rigidbody2D>();
        timer = 0;

        onGroun = false;

        // ゲームオブジェクトのSkeletonAnimationを取得
        skeletonAnimation = GetComponent<SkeletonAnimation>();

        // SkeletonAnimationからAnimationStateを取得
        spineAnimationState = skeletonAnimation.AnimationState;

        _skeletonAnimation = GetComponent<SkeletonAnimation>();

        scale = transform.localScale;
    }

    private void Update()
    {
        if (PlayerMove.PlayerDead)
        {
            return;
        }
        timer += Time.deltaTime;

        if (smoke != null)
        {
            Destroy(smoke, 3.0f);
        }

        if (onGroun)
        {

            //smokePos = new Vector3(GroundPos.x, this.gameObject.transform.position.y - 0.5f, this.gameObject.transform.position.z);
            this.gameObject.transform.position = GroundPos;
        }

        if (timer > 5 && onGroun)
        {
            onGroun = false;
            float plusY = Random.Range(0, 3);
            rg.velocity = new Vector2(0, 12.5f+plusY);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            rg.gravityScale = 0;
            timer = 0;
            this.gameObject.transform.DOMoveY(this.transform.position.y - 1, 2.0f).OnComplete(OnGround);
            Pary.SetActive(false);
        }

        if (collision.gameObject.tag == "Wall")
        {
            Destroy(smoke);
            Destroy(this.gameObject);
        }
    }
        
    private void OnCollisionExit2D(Collision2D collision)
    {
        rg.gravityScale = 2.5f;
        this.tag = "Enemy";
        PlayJumpAnimation();
        Pary.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (PlayerMove.PlayerDead)
        {
            return;
        }

        if (other.gameObject.CompareTag("Drop"))
        {
            EXPController.EXP += 8.0f * PlayerMove.EXPUP;
            PlayerMove.EXPUP += 1;
            ScoreManager.bigEnemyKillCount++;
            Destroy(smoke);
            Destroy(this.gameObject);
        }
    }

    private void OnGround()
    {
        GroundPos = new Vector3(player.gameObject.transform.position.x, this.gameObject.transform.position.y, 0);
        smoke = Instantiate(smokePrefab, new Vector3(GroundPos.x,this.transform.position.y+0.25f,1), Quaternion.identity);
        onGroun = true;
        this.tag = "Untagged";
    }

    private void PlayJumpAnimation()
    {
        TrackEntry trackEntry = spineAnimationState.SetAnimation(0, Jump, false);

        trackEntry.Complete += OnSpineComplete;
    }

    private void OnSpineComplete(TrackEntry trackEntry)
    {
        // アニメーション完了時に行う処理を記載
        spineAnimationState.SetAnimation(0, Normal, true);
    }
}
