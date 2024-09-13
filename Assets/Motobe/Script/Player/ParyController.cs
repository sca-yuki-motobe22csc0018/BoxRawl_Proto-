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
    float autoPary;
    public static int DekoifreMax;
    int Dekoifre;
    public static bool playerOnGround;
    // Start is called before the first frame update
    void Start()
    {
        parySet = false;
        paryJump = false;
        autoPary = 0;
        Dekoifre = 0;
        DekoifreMax = 0;
        playerOnGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOnGround)
        {
            Dekoifre = 0;
            playerOnGround = false;
        }
        transform.position = PlayerObject.transform.position;
        if (parySet)
        {
            if (Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0)) 
            {
                if (DekoifreMax > Dekoifre)
                {
                    SpawnDekoi();
                    Dekoifre += 1;
                }
                PlayerMove.ParyJump = true;
                PlayerMove.paryCheck = true;
                SEController.pary = true;
                //autoPary = 0;
            }
             //&& autoPary > 0.2f
        }
        autoPary += Time.deltaTime;
    }

    private void DekoiObject(float x, float y)
    {
        GameObject Dekoi_prefab = Resources.Load<GameObject>("PlayerDekoi");
        GameObject Dekoi = Instantiate(Dekoi_prefab, new Vector3(x, y, 0), Quaternion.identity);
        return;
    }

    void SpawnDekoi()
    {
        DekoiObject(this.transform.position.x, this.transform.position.y);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyPary")
        {
            parySet = true;
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
