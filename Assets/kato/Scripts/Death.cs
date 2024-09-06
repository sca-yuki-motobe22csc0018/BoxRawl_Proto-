using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Death : MonoBehaviour
{
    [SerializeField] GameObject[] fragmentObj = new GameObject[5];
    Rigidbody2D[] Rg = new Rigidbody2D[5];

    [SerializeField] SpriteRenderer[] skinSpr = new SpriteRenderer[2];

    public int breakPower = 600;

    void Start()
    {
        for (int i = 0; i < fragmentObj.Length; i++)
        {
            Rg[i] = fragmentObj[i].GetComponent<Rigidbody2D>();
        }
        breakPower = 600;

        skinSpr[0].DOFade(0, 1.0f);
        skinSpr[1].DOFade(0, 1.0f);
        Invoke("breack", 1);
    }

    void Update()
    {
    }

    /// <summary>
    /// âÛÇÍÇÈââèo
    /// </summary>
    void breack()
    {
        for (int i = 0; i < fragmentObj.Length; i++)
        {
            Rg[i].constraints = RigidbodyConstraints2D.None;

            Vector2 force = fragmentObj[i].transform.position - this.gameObject.transform.position;
            Vector2 force_test = new Vector2(10, 10);
            Rg[i].AddForce(force * breakPower);
        }
    }
}
