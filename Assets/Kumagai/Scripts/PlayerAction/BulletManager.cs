using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public string moveDirection;
    private float speed;
    private float power = 1000;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        speed=20;
    }

    // Update is called once per frame
    void Update()
    {
        switch (moveDirection)
        {
            case "R":
                {
                    dir=new Vector3(1,0,0).normalized;
                }
                break;
            case "L":
                {
                    dir = new Vector3(-1, 0, 0).normalized;
                }
                break;
            case "U":
                {
                    dir = new Vector3(0, 1, 0).normalized;
                }
                break;
            case"D":
                {
                    dir = new Vector3(0, -1, 0).normalized;
                }
                break;
            case"RU":
                {
                    dir = new Vector3(1, 1, 0).normalized;
                }
                break;
            case"LU":
                {
                    dir = new Vector3(-1, 1, 0).normalized;
                }
                break;
            case"RD":
                {
                    dir = new Vector3(1, -1, 0).normalized;
                }
                break;
            case "LD":
                {
                    dir = new Vector3(-1, -1, 0).normalized;
                }
                break;
        }
        transform.Translate(dir * Time.deltaTime*speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Rigidbody2D>().AddForce(dir * power);
        }
    }
}
