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
        SetEventType(enter,setEvent);

        setEvent = new SetEvent(PointerDown);
        SetEventType(down, setEvent);

        setEvent=new SetEvent(PointerExit);
        SetEventType(exit, setEvent);
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
