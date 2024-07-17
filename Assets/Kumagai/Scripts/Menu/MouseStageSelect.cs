using System.Collections;
using System.Collections.Generic;
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
        Debug.Log("オーバーライド");//基底クラスのバーチャル関数が呼び出されていないかのチェック
    }

    public override void PointerDown()
    {
        StageSelect.getKeySpace();
        Debug.Log("オーバーライド");
    }
}
