using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseStageSelect : MouseSelect
{
    [SerializeField]private int x;
    [SerializeField]private int y;
    public override void PointerEnter()
    {
        Debug.Log("�I�[�o�[���C�h");//���N���X�̃o�[�`�����֐����Ăяo����Ă��Ȃ����̃`�F�b�N
    }

    public override void PointerDown()
    {
        Debug.Log("�I�[�o�[���C�h");
    }

}
