using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class MouseSelect : MonoBehaviour//このクラスはマウス対応の際に必要な基底クラスです
{
    public delegate void SetEvent();
    private string corectEventID;
    public virtual void PointerEnter()
    {
        Debug.Log("基底クラス側の関数が呼ばれています");//基底クラス側の関数が呼び出されていることを知らせる
    }

    public virtual void PointerDown() 
    {
        Debug.Log("基底クラス側の関数が呼ばれています");//基底クラス側の関数が呼び出されていることを知らせる
    }

    public virtual void PointerExit()
    {
    }

    public virtual void SetEventType(string eventID,SetEvent e)
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
       
        switch(eventID)
        {
            case ("Enter"):
                {
                    entry.eventID = EventTriggerType.PointerEnter;
                }
                break;
            case ("Down"):
                {
                    entry.eventID= EventTriggerType.PointerDown;
                }
                break;
            case ("Exit"):
                {
                    entry.eventID=EventTriggerType.PointerExit;
                }
                break;
            case ("Up"):
                {
                    entry.eventID = EventTriggerType.PointerUp;
                }
                break;
        }
       
        entry.callback.AddListener((data) => {  e() ; });
        trigger.triggers.Add(entry);
    }
}
