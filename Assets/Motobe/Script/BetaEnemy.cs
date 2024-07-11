using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;


public class BetaEnemy : MonoBehaviour
{
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



    // Start is called before the first frame update
    void Start()
    {
        // ゲームオブジェクトのSkeletonAnimationを取得
        skeletonAnimation = GetComponent<SkeletonAnimation>();

        // SkeletonAnimationからAnimationStateを取得
        spineAnimationState = skeletonAnimation.AnimationState;

        _skeletonAnimation = GetComponent<SkeletonAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayJumpAnimationA()
    {
        TrackEntry trackEntry = spineAnimationState.SetAnimation(0, JumpA, true);

        trackEntry.Complete += OnSpineComplete;
    }
    private void PlayJumpAnimationC()
    {
        spineAnimationState.SetAnimation(0, JumpC, true);
    }

    private void OnSpineComplete(TrackEntry trackEntry)
    {
        // アニメーション完了時に行う処理を記載
        spineAnimationState.SetAnimation(0, JumpB, true);
    }
}
