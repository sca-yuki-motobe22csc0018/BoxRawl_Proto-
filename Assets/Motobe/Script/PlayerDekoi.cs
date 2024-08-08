using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDekoi : MonoBehaviour
{
    //Rigidbody
    private Rigidbody2D rb;
    bool a;
    public GameObject dekoiPary;
    public static bool dekoiDrop;
    public GameObject dropObject;
    public static bool dekoiDestroy;

    // Start is called before the first frame update
    void Start()
    {
        dropObject.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        //Set = false;
        dekoiDrop = false;
        dekoiDestroy = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dekoiDestroy)
        {
            Destroy(this.gameObject);
        }
        dekoiPary.transform.Rotate(0, 0, 550 * -1 * Time.deltaTime);
        transform.Rotate(0, 0, 750 * -1 * Time.deltaTime);
        if (PlayerMove.Drop)
        {
            a = true;
            dekoiDrop = true;
            DropSystem();
        }
        if (a == true)
        {
            Vector2 myGravity = new Vector2(0, -9.81f * 200 * Time.deltaTime);
            rb.AddForce(myGravity);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    public void DropSystem()
    {
        var sequence = DOTween.Sequence();
        rb.velocity = new Vector3(0, 15, 0);

        if (PlayerSkin.rota == 0)
        {
            PlayerSkin.rota = 1;
        }

        PlayerSkin.rota *= -2;
        sequence.AppendInterval(0.2f);
        sequence.AppendCallback(() => DropSystem2());
    }
    public void DropSystem2()
    {
        dropObject.SetActive(true);
        PlayerSkin.Rota = false;
        PlayerSkin.rota = 0;
        rb.velocity = new Vector3(0, -15 * 2, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            a = false;
            SEController.drop2 = true;
            dekoiDrop = false;
            Destroy(this.gameObject);
        }
    }
}
