using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MagnetismManager : MonoBehaviour
{
    public static int MagnetismLv = 0;
    //[SerializeField] private GameObject player;
    [SerializeField] private float size;
    [SerializeField] private GameObject magnObj;
    GameObject insObject;
    private void OnEnable()
    {
       
    }

    private void Update()
    {
        if (ParyController.parySet&&!PlayerMove.Drop)
        {
            if(Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))
            {
                if (MagnetismLv > 3)
                {
                    MagnetismLv = 3;
                }
                if (insObject == null)
                {
                    insObject = Instantiate(magnObj, transform.position, Quaternion.identity);
                    insObject.transform.localScale = new Vector3(MagnetismLv, MagnetismLv, MagnetismLv) * size;

                }
            }
            
          
        }
        Debug.Log(insObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
    }
}
