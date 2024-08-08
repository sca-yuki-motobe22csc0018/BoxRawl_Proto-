using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    float sin;
    public static bool size;
    public GameObject[] pos;
    public static int posNum;
    public static bool levelUpEnd;
    // Start is called before the first frame update
    void Start()
    {
        levelUpEnd = false;
        size = false;
        posNum = 1;
        // 0 1 2
    }

    // Update is called once per frame
    void Update()
    {
        
        if (size)
        {
            if (posNum == 0)
            {
                this.transform.position = new Vector3(pos[0].transform.position.x, pos[0].transform.position.y,1); 
            }else if (posNum == 1)
            {
                this.transform.position = new Vector3(pos[1].transform.position.x, pos[1].transform.position.y, 1);
            }
            else if (posNum == 2)
            {
                this.transform.position = new Vector3(pos[2].transform.position.x, pos[2].transform.position.y, 1);
            }
            sin = Mathf.Sin(Time.time * 6);
            if (sin > 0.8f)
            {
                this.gameObject.transform.localScale = new Vector3(14 * sin * 1.2f, 12 * sin * 1.2f, 1);
            }
            else if (sin < -0.8f)
            {
                this.gameObject.transform.localScale = new Vector3(14 * sin * 1.2f, 12 * sin * 1.2f, 1);
            }
            if (Input.GetKeyDown(KeyCode.A) && posNum > 0)
            {
                posNum -= 1;
            }
            if (Input.GetKeyDown(KeyCode.D) && posNum < 2)
            {
                posNum += 1;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (posNum == 0)
                {
                    StateController.level01 += 1;
                }
                if (posNum == 1)
                {
                    StateController.level02 += 1;
                }
                if (posNum == 2)
                {
                    StateController.level03 += 1;
                }
                levelUpEnd = true;
            }
        }
    }
}
