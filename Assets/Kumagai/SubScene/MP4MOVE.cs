using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP4MOVE : MonoBehaviour
{
    [SerializeField]private GameObject obj;
    [SerializeField]private GameObject canvas;
    //Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(obj);
        }
    }
}
