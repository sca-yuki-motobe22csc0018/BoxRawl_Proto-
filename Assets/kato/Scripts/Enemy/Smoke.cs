using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���O�����o���y���̏���
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
