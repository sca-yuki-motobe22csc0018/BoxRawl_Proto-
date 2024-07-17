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
        Debug.Log("オーバーライド");//基底クラスのバーチャル関数が呼び出されていないかのチェック
    }

    public override void PointerDown()
    {
        Debug.Log("オーバーライド");
    }

}
