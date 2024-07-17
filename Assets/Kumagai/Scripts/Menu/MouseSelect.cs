using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelect : MonoBehaviour
{

    public virtual void PointerEnter()
    {
        Debug.Log("バーチャル");
    }

    public virtual void PointerDown() 
    {
        Debug.Log("バーチャル");
    }
}
