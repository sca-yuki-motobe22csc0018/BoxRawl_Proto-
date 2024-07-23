using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDekoi : MonoBehaviour
{

    public static bool Set;
    public GameObject Player;
    //Rigidbody
    private Rigidbody2D rb;
    bool a;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Set = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Set)
        {
            this.transform.position = Player.transform.position;
            Set = false;
        }
        if (PlayerMove.Drop)
        {
            a = true;
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
        PlayerSkin.Rota = false;
        PlayerSkin.rota = 0;
        rb.velocity = new Vector3(0, -15 * 2, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log(a);
            a = false;
            SEController.drop2 = true;
            //Destroy(this);
        }
    }
}
