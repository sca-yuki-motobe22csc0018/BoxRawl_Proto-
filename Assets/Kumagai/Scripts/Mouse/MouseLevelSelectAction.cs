using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MouseSelect;

public class MouseLevelSelectAction : MouseSelect
{

    BoxCollider2D bc;
    bool mouseFlag = false;
    Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        mouseFlag = true;
        //SetEvent setEvent = new SetEvent(PointerEnter);
        //SetEventType(enter, setEvent);

        //setEvent = new SetEvent(PointerDown);
        //SetEventType(down, setEvent);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmpMPos = Input.mousePosition;
        if(mousePos!=tmpMPos)
        {
            mousePos = Input.mousePosition;
            mouseFlag = true;
        }
        if(Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.S))
        {
            mouseFlag = false;
        }
        if(mouseFlag)
        {
            if (mousePos.x >= 200 && mousePos.x < 600)
            {
                LevelSelect.posNum = 0;
                //Debug.Log(1);
            }

            if (mousePos.x >= 750 && mousePos.x < 1200)
            {
                LevelSelect.posNum = 1;
                //Debug.Log(2);
            }

            if (mousePos.x >= 1300 && mousePos.x < 1700)
            {
                LevelSelect.posNum = 2;
                //Debug.Log(3);
            }
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
