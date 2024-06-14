using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetPlayerType : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] skin;
    SpriteRenderer nowSprite;
    [SerializeField] GameObject nowSelectType;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer=this.gameObject.GetComponent<SpriteRenderer>();
        nowSprite=nowSelectType.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(StatusUp.nowPlayerType)
        {
            case "Defult":
                {
                    spriteRenderer.sprite = skin[0];
                }
                break;
            case "Speed":
                {
                    spriteRenderer.sprite = skin[1];
                }
                break;
            case "Hp":
                {
                    spriteRenderer.sprite = skin[2];
                }
                break;
            case "Jump":
                {
                    spriteRenderer.sprite = skin[3];
                }
                break;
        }
        nowSprite.sprite = skin[StatusUp.selectTypeNumber];
    }
}
