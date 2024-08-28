using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MouseSelect;

public class MouseLevelSelectAction : MouseSelect
{
    [SerializeField] int myNumber;

    BoxCollider2D bc;
    Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        SetEvent setEvent = new SetEvent(PointerEnter);
        SetEventType(enter, setEvent);

        setEvent = new SetEvent(PointerDown);
        SetEventType(down, setEvent);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        Debug.Log(mousePos);
        if(mousePos.x>=200&&mousePos.x<600)
        {
            //1
        }

        if(mousePos.x>=750&&mousePos.x<1200)
        {
            //2
        }

        if(mousePos.x>=1300&&mousePos.x<1700)
        {
            //3
        }
    }

    override public void  PointerEnter()
    {
        Debug.Log("11111");
       // LevelUpSelect.set = myNumber;
    }

    public override void PointerDown()
    {
      //  LevelSelect.LevelUp();
    }
}
