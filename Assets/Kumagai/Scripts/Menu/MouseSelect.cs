using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class MouseSelect : MonoBehaviour
{
    public delegate void SetEvent(string mouseEvent);
    public virtual void PointerEnter()
    {
        Debug.Log("バーチャル");
    }

    public virtual void PointerDown() 
    {
        Debug.Log("バーチャル");
    }

    public virtual void PointerExit(string str)
    {
    }

    public virtual void SetEventType(string eventID,SetEvent e,string debStr)
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => {  e(debStr) ; });
        trigger.triggers.Add(entry);
    }
}
