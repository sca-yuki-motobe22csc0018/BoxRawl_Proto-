using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTypeSelect : MonoBehaviour
{
    [SerializeField] private GameObject[] playerTypes;
    public int selectNumber;
    [SerializeField] private float MaxSize;
    private float startSize;
    float x;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        startSize = playerTypes[0].transform.localScale.x;  
        x = startSize;
        y = startSize;  
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.DownArrow))
        {
            x = startSize;
            y = startSize;
            if (selectNumber == 3)
            {
                selectNumber = 0;
            }
            else
            {
                selectNumber++;
            }
           
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            x = startSize;
            y = startSize;
            if (selectNumber==0)
            {
                selectNumber = 3;
            }
            else
            {
                selectNumber--;
            }
        }
        if ((playerTypes[selectNumber].transform.localScale.x < startSize * MaxSize))
        {
            Debug.Log("’Ê‰ß‚µ‚Ä‚¢‚Ü‚·");
            x += Time.deltaTime*2;
            y += Time.deltaTime*2;
            playerTypes[selectNumber].transform.localScale = new Vector3(x, y, 1);
        }
        StartCoroutine(SizeUp(selectNumber));
        for(int i = 0; i < playerTypes.Length; i++)
        {
            if(i!=selectNumber)
            {
                playerTypes[i].transform.localScale= new Vector3 (startSize, startSize, startSize);
            }
        }

    }
    private IEnumerator SizeUp(int i)
    {
     
        while (playerTypes[i].transform.localScale.x < startSize * MaxSize)
        {
          
            yield return null;
        }
    }


    //private IEnumerator SizeDown(int i)
    //{
    //    float x = playerTypes[i].transform.localScale.x;
    //    float y = playerTypes[i].transform.localScale.y;
    //    while (playerTypes[i].transform.localScale.x > startSize)
    //    {
    //        Debug.Log("’Ê‰ß‚µ‚Ä‚¢‚Ü‚·");
    //        x -= Time.deltaTime;
    //        y -= Time.deltaTime;
    //        playerTypes[i].transform.localScale = new Vector3(x, y, 1);
    //        yield return null;
    //    }
    //}
}
