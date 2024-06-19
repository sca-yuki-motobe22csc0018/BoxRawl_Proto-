using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetPlayerType : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] skin;
    [SerializeField] GameObject playerSkin;
   
    // Start is called before the first frame update
    void Start()
    {
       spriteRenderer=playerSkin.GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        switch (StatusUp.nowPlayerType)
        {
            case "Defult":
                {
                    spriteRenderer.sprite = skin[0];
                    Debug.Log("a");
                }
                break;
            case "Speed":
                {
                    spriteRenderer.sprite = skin[1];
                    Debug.Log("b");
                }
                break;
            case "Hp":
                {
                    spriteRenderer.sprite = skin[2];
                    Debug.Log("c");
                }
                break;
            case "Jump":
                {
                    spriteRenderer.sprite = skin[3];
                    Debug.Log("d");
                }
                break;
        }
     
    }
}
