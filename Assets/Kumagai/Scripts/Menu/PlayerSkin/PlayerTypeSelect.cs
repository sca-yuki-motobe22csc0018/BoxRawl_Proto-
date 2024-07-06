using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerTypeSelect : MonoBehaviour
{
    [SerializeField] private GameObject[] playerTypes;
    [SerializeField] private GameObject player;
    private GameObject insPlayer;
    [SerializeField] private GameObject[] selectorPos;
    public static int selectNumber;
    [SerializeField] private float MaxSize;
    [SerializeField] private float iconSize;
    private float startSizeX;
    private float startSizeY;
    float x;
    float y;

    private void OnEnable()
    {
        selectNumber = 0;
       
        InsObject();
        //PlayerSkin.Rota = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        startSizeX = playerTypes[0].transform.localScale.x;
        startSizeY = playerTypes[0].transform.localScale.y;
        x = startSizeX;
        y = startSizeY;  
    }

    // Update is called once per frame
    void Update()
    {
     //   PlayerSkin.Rota = true;
        insPlayer.SetActive(true);
        insPlayer.transform.position = selectorPos[StatusUp.selectTypeNumber].transform.position;
        if (Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.DownArrow))
        {
            x = startSizeX;
            y = startSizeY;
            if (selectNumber == 4)
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
            x = startSizeX;
            y = startSizeY;
            if (selectNumber==0)
            {
                selectNumber = 4;
            }
            else
            {
                selectNumber--;
            }
        }
        if ((playerTypes[selectNumber].transform.localScale.x < startSizeX * MaxSize))
        {
            Debug.Log("’Ê‰ß‚µ‚Ä‚¢‚Ü‚·");
            x += Time.deltaTime*2;
            y += Time.deltaTime*2;
            playerTypes[selectNumber].transform.localScale = new Vector3(x, y, 1);
        }
        for(int i = 0; i < playerTypes.Length; i++)
        {
            if(i!=selectNumber)
            {
                playerTypes[i].transform.localScale= new Vector3 (startSizeX, startSizeY, 1);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(selectNumber != 4)
            {
                StatusUp.selectTypeNumber = selectNumber;
                StartCoroutine(FALSE());
               

            }
            else
            {
                if (insPlayer != null)
                {
                    Destroy(insPlayer);
                    insPlayer = null;
                }
                ButtonManager.sceneCheck = false;
                StatusUp.selectType = false;

               // PlayerSkin.Rota = false;
            }

        }
    }

    IEnumerator FALSE()
    {
        yield return new WaitForSeconds(0.01f);
        if(insPlayer!=null)
        {
            Destroy(insPlayer);
            insPlayer = null;
        }
        InsObject();
       
       
    }
    
    private void InsObject()
    {
       
        if (insPlayer == null&&selectNumber!=4)
        {
            insPlayer = Instantiate(player);
        }
        //insPlayer.transform.parent = playerTypes[StatusUp.selectTypeNumber].transform;
        insPlayer.SetActive(false);
        insPlayer.GetComponent<SpriteRenderer>().sortingOrder = 10000;
        insPlayer.transform. localScale= new Vector3(0.8f, 0.8f, 1);
        Destroy(insPlayer.GetComponent<PlayerMove>());
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
