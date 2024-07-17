using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseStageSelect : MouseSelect
{
    [SerializeField]private int x;
    [SerializeField]private int y;
    [SerializeField] private GameObject dscriptWindow;
    Vector3 firstPos;

    private void Start()
    {

        firstPos = transform.localPosition;
        SetEvent setEvent = new SetEvent(PointerExit);
        SetEventType("",setEvent,"event�ǉ�");
    }

    private void Update()
    {
        if(!dscriptWindow.activeSelf)
        {
            transform.localPosition = firstPos;
        }
    }
    public override void PointerEnter()
    {
        StageSelect.x = x; 
        StageSelect.y = y;
        Debug.Log("�I�[�o�[���C�h");//���N���X�̃o�[�`�����֐����Ăяo����Ă��Ȃ����̃`�F�b�N
    }

    public override void PointerDown()
    {
        StageSelect.getKeySpace();
        Debug.Log("�I�[�o�[���C�h");
    }

    public override void PointerExit(string str)
    {
        Debug.Log(str);
    }
}
