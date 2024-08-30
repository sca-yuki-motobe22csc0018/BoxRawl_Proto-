using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class TutorialPary : MonoBehaviour
{
    Rigidbody2D rb;
    private float x;
    [SerializeField] private float speed;
    [SerializeField] private float wait;
    [SerializeField] private int jumpPower;
    public bool canPary;
    bool rota;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        x=transform.position.x;
        StartCoroutine(jump());
    }

    // Update is called once per frame
    void Update()
    {
        x += Time.deltaTime * speed;
        transform.position = new Vector3(x, transform.position.y, 0);
        if(canPary)
        {
            rb.AddForce(new Vector3(0, jumpPower, 0));
            canPary = false;
        }
        if(rota)
        {
            this.gameObject.transform.Rotate(0, 0, -700*Time.deltaTime*speed);
        }
    }
    IEnumerator jump()
    {
        yield return new WaitForSeconds(wait); ;
        rb.AddForce(new Vector3(0, jumpPower, 0));
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.CompareTag("Ground"))
       {
            rota = false;
       }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rota = true;
        }
    }
}
