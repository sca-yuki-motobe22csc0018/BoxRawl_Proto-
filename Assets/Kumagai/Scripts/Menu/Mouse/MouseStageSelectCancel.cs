using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseStageSelectCancel : MouseSelect
{ 
    // Start is called before the first frame update
    void Start()
    {
        SetEvent setEvent=new SetEvent(PointerEnter);
        SetEventType(enter,setEvent);

        setEvent=new SetEvent(PointerDown);
        SetEventType(down,setEvent);

        setEvent=new SetEvent(PointerExit);
        SetEventType(exit,setEvent);    
    }

    public override void PointerEnter()
    {
        StageSelect.onCursor=true;
        StageSelect.y=-1;
    }
    public override void PointerDown()
    {
        StartCoroutine(StageSelect.jumpSet());
    }

    public override void PointerExit()
    {
        StageSelect.onCursor = false;
    }
}
