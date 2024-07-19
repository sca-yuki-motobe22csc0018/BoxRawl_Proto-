using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseDiscriptCancel : MouseSelect
{
    private void Start()
    {
        SetEvent setEvent = new SetEvent(PointerEnter);
        SetEventType(enter, setEvent);

        setEvent = new SetEvent(PointerDown);
        SetEventType(down, setEvent);

        setEvent = new SetEvent(PointerExit);
        SetEventType(exit, setEvent);
    }


    public override void PointerEnter()
    {
        StageDscript.cancelFlag=true;
    }

    public override void PointerDown()
    {

        StageSelect.stages[StageSelect.x, StageSelect.y].transform.position = StageDscript.tmpStagePos;
        StageSelect.stages[StageSelect.x, StageSelect.y].transform.localScale = StageDscript.tmpSize;
        StageSelect.stages[StageSelect.x, StageSelect.y].GetComponent<SpriteRenderer>().sortingOrder = 15;
        StageSelect.descriptionFlag = false;
    }

    
}
