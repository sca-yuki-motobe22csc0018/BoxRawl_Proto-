using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayerSkin : MonoBehaviour
{
    [SerializeField] GameObject playerType;
    [SerializeField] Sprite[] skin;
    SpriteRenderer nowSprite;
    // Start is called before the first frame update
    void Start()
    {
        nowSprite=playerType.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StatusUp.selectTypeNumber>=0&&StatusUp.selectTypeNumber<4)
        {
            nowSprite.sprite = skin[StatusUp.selectTypeNumber];
        }
    }
}
