using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] GameObject[] fragmentObj = new GameObject[5];
    Rigidbody2D[] Rg = new Rigidbody2D[5];

    void Start()
    {
        for (int i = 0; i < fragmentObj.Length; i++)
        {
            Rg[i] = fragmentObj[i].GetComponent<Rigidbody2D>();
        }

    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.A))
        {
            for (int i = 0; i < fragmentObj.Length; i++)
            {
                Rg[i].constraints = RigidbodyConstraints2D.None;

                Vector2 force = fragmentObj[i].transform.position - this.gameObject.transform.position;
                Vector2 force_test = new Vector2 (10,10);
                Rg[i].AddForce(force*1000);
            }
        }
    }
}
