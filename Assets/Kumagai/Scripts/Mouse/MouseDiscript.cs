using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MouseDiscript : MouseSelect
{


    BoxCollider2D bc;
    Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        SetEvent setEvent=new SetEvent(PointerEnter);
        SetEventType(enter,setEvent);

        setEvent=new SetEvent(PointerDown);
        SetEventType(down,setEvent);    
    }

    private void Update()
    {
        mousePos=Input.mousePosition;
    }

    public override void PointerEnter()
    {
        StageDscript.cancelFlag = false;
    }

    public override void PointerDown()
    {
        ButtonManager.thisSceneName = "Main Game";
        ButtonManager.yesOrNo = "Yes";
    }

}
