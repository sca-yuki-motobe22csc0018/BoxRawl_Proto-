using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpShot : MonoBehaviour
{
    public static int shotLv;
    private int loop;
    [SerializeField] GameObject bullet;
    [SerializeField] float shotDelay;
    private bool coolTime;
    [SerializeField]private float setCoolTimer;
    private float coolTimer;
    private string[] direction = { "R","L","D","U","RU","LU","RD","LD"};
    // Start is called before the first frame update
    void Start()
    {
        shotLv=0;
        coolTime=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(shotLv<3)
        {
            loop=shotLv*2;
        }
        else
        {
            loop=8;
        }
        if(!ButtonManager.sceneCheck)
        {
            if (PlayerMove.JumpCount == 0)
            {
                if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
                {
                    if (!coolTime)
                    {
                        coolTime = true;
                        coolTimer = setCoolTimer;
                        StartCoroutine(shot());
                    }
                }
            }
            if (coolTimer > 0 && coolTime)
            {
                //Debug.Log("A");
                coolTimer -= Time.deltaTime;
            }
            else if (coolTimer < 0)
            {
                coolTime = false;
            }
        }
       
    }

    IEnumerator shot()
    {
        yield return new WaitForSeconds(shotDelay);
        GameObject insObj;
        var BM = new BulletManager();
        for (int i = 0; i < loop; i++)
        {
            insObj = Instantiate(bullet, transform.position, Quaternion.identity);
            BM = insObj.GetComponent<BulletManager>();
            BM.moveDirection = direction[i];
        }
    }
}
