using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP4 : MonoBehaviour
{
    [SerializeField]private GameObject obj;
    [SerializeField]private GameObject canvas;
    [SerializeField]private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(obj,player.transform.position,Quaternion.identity,canvas.transform);
        }
    }
}
