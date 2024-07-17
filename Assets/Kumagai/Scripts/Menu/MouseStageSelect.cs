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
        SetEvent setEvent = new SetEvent(PointerEnter);
        SetEventType("Enter",setEvent);

        setEvent = new SetEvent(PointerDown);
        SetEventType("Down", setEvent);

        setEvent=new SetEvent(PointerExit);
        SetEventType("Exit", setEvent);
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
        StageSelect.onCursor = true;
        StageSelect.x = x; 
        StageSelect.y = y;
        Debug.Log("Enter");//基底クラスのバーチャル関数が呼び出されていないかのチェック
    }

    public override void PointerDown()
    {
        StageSelect.getKeySpace();
        Debug.Log("Down");
    }

    public override void PointerExit()
    {
        StageSelect.onCursor = false;   
        Debug.Log("Exit");
    }
}
