using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class ParyController : MonoBehaviour
{
    public GameObject PlayerObject;
    public static bool parySet;
    public static bool paryJump;
    public GameObject dekoi;
    // Start is called before the first frame update
    void Start()
    {
        parySet = false;
        paryJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PlayerObject.transform.position;
        if (parySet)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
            {
                //PlayerMove.JumpCount = 1;
                dekoi.SetActive(true);
                PlayerMove.ParyJump = true;
                PlayerMove.paryCheck = true;
                SEController.pary = true;
                PlayerDekoi.Set = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyPary")
        {
            //if (Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.Space))
            {
                //PlayerMove.JumpCount = 0;
                parySet = true;
                
            }
          
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyPary")
        {
            //PlayerMove.JumpCount = 1;
            //PlayerMove.ParyJump = false;
            parySet = false;
            paryJump = false;
            PlayerMove.paryCheck = false;
        }
    }
}
