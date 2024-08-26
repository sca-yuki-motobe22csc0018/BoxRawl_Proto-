using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTypeMouse : MouseSelect
{
    [SerializeField] private int myNumber;
    // Start is called before the first frame update
    void Start()
    {
        SetEvent setEvent = new SetEvent(PointerEnter);
        SetEventType(enter, setEvent);

        setEvent = new SetEvent(PointerDown);
        SetEventType(down, setEvent);
    }

    public override void PointerEnter()
    {
        PlayerTypeSelect.selectNumber = myNumber;
        Debug.Log("myNumber" + myNumber);
    }

    public override void PointerDown()
    {
        PlayerTypeSelect.mouseCheck=true;
    }
}
