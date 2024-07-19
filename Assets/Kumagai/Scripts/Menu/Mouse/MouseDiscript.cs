using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MouseDiscript : MouseSelect
{


    // Start is called before the first frame update
    void Start()
    {
        SetEvent setEvent=new SetEvent(PointerEnter);
        SetEventType(enter,setEvent);

        setEvent=new SetEvent(PointerDown);
        SetEventType(down,setEvent);    
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
