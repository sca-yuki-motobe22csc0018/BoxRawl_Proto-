using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Spine;
using Spine.Unity;
using UnityEngine;

public class BeeSkin : MonoBehaviour
{
    public GameObject PlayerObj;
    public GameObject mainObj;
    [SerializeField]
    private string Attack;

    [SerializeField]
    private string Attack2;

    [SerializeField]
    private string Normal;

    private SkeletonAnimation _skeletonAnimation;
    public static bool anim;
    public static bool anim2;
    Vector3 scale;

    /// <summary> ゲームオブジェクトに設定されているSkeletonAnimation </summary>
    private SkeletonAnimation skeletonAnimation = default;

    /// <summary> Spineアニメーションを適用するために必要なAnimationState </summary>
    private Spine.AnimationState spineAnimationState = default;
    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
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

            this.transform.position = new Vector3(mainObj.transform.position.x - 0.5f, mainObj.transform.position.y + 0.5f, 1);
        }
        else
        {
            scale.x = 0.3f;
            scale.y = 0.3f;
            transform.localScale = scale;

            this.transform.position = new Vector3(mainObj.transform.position.x + 0.5f, mainObj.transform.position.y + 0.5f, 1);
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
