using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// モグラが出す土煙の処理
/// </summary>
public class Smoke : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject,3.0f);
    }
}
