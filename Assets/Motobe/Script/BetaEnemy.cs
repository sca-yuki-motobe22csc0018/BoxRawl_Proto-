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

    /// <summary> �Q�[���I�u�W�F�N�g�ɐݒ肳��Ă���SkeletonAnimation </summary>
    private SkeletonAnimation skeletonAnimation = default;

    /// <summary> Spine�A�j���[�V������K�p���邽�߂ɕK�v��AnimationState </summary>
    private Spine.AnimationState spineAnimationState = default;



    // Start is called before the first frame update
    void Start()
    {
        // �Q�[���I�u�W�F�N�g��SkeletonAnimation���擾
        skeletonAnimation = GetComponent<SkeletonAnimation>();

        // SkeletonAnimation����AnimationState���擾
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
        // �A�j���[�V�����������ɍs���������L��
        spineAnimationState.SetAnimation(0, JumpB, true);
    }
}
