using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyProto4 : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] bool OnGround;
    [SerializeField] bool OnWall;
    [SerializeField] bool hitPlayer;
    [SerializeField] private bool hitDirUp;
    [SerializeField] private bool hitDirDown;
    [SerializeField] private bool hitDirRight;
    [SerializeField] private bool hitDirLeft;
    SpriteRenderer spriteRendere;
    Vector3 target;
    private float momongaUp = 15;
    private bool momongaUpFlag;
    private bool momongaDownFlag;
    bool Rota;
    int rota;

    public float speed;
    float defaultSpeed;
    bool right;
    int dir;

    bool Jump;

   // public GameObject EnemySkin;
    private GameObject player;
    private bool myIsTrigger;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        momongaUpFlag = false;
        spriteRendere = GetComponent<SpriteRenderer>();
        momongaDownFlag = true;
        OnGround = false;
        right = false;
        dir = 1;
        Jump = false;
        defaultSpeed = speed;
        player = GameObject.Find("Player").gameObject;
        target = player.transform.position - transform.position;
        Rota = true;
        int a = Random.Range(0, 2);
        Debug.Log(Resources.Load<GameObject>("MomongaSprite/Momonga_0"+(a+1).ToString()).GetComponent<SpriteRenderer>().sprite);
        spriteRendere.sprite = Resources.Load<GameObject>("MomongaSprite/Momonga_01").GetComponent<SpriteRenderer>().sprite;

    }

    // Update is called once per frame
    void Update()
    {
        //posy = transform.position.y;
        //posx = transform.position.x;
        //posx += speed * Time.deltaTime * dir;
        //transform.position = new Vector3(posx, posy);
        //if (!OnGround)
        //{
        //    Vector2 myGravity = new Vector2(0, -9.81f * 200 * Time.deltaTime);
        //    rb.AddForce(myGravity);
        //}
        if (right)
        {
            dir = 1;
            rota = -1;
        }
        else
        {
            dir = -1;
            rota = 1;
        }
        //if (Jump)
        //{
        //    rb.velocity = new Vector3(0, 13, 0);
        //    Jump = false;
        //}

        //if (Rota)
        //{
        //    EnemySkin.transform.Rotate(0, 0, 750 * rota * Time.deltaTime);
        //}
        //if (!Rota)
        //{
        //    EnemySkin.transform.rotation = new Quaternion(0, 0, 0, 0);
        //}
        MomongaEnemy();
    }


    private void MomongaEnemy()
    {
        HitRay(Vector3.up);
        if (this.transform.position.y > momongaUp || hitDirUp)
        {
            momongaUpFlag = false;
            momongaDownFlag = true;
        }
        if (momongaDownFlag)
        {
            target = player.transform.position - this.gameObject.transform.position;//EnmeyからPlayerへのベクトル
            target = target.normalized;//ベクトルの正規化
            momongaDownFlag = false;
        }
        if (OnGround || hitPlayer)
        {
            momongaUpFlag = true;
            int a = Random.Range(0, 2);
            Debug.Log(Resources.Load<GameObject>("MomongaSprite/Momonga_0" + (a + 1).ToString()).GetComponent<SpriteRenderer>().sprite);
            spriteRendere.sprite = Resources.Load<GameObject>("MomongaSprite/Momonga_01").GetComponent<SpriteRenderer>().sprite;
            Rota = false;
        }
        if (OnWall)
        {
            target.x = 0;
            Rota = false;
        }

        if (momongaUpFlag)
        {
            Vector3 pos = transform.position;
            pos.y += speed * Time.deltaTime;
            transform.position = new Vector3(pos.x, pos.y, pos.z);
        }
        else
        {
            transform.position += target * speed * Time.deltaTime;
        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hitPlayer = true;

        }
        if (other.gameObject.CompareTag("Ground"))
        {
            if (speed != defaultSpeed)
            {
                speed = defaultSpeed;
            }
        }
        if (other.gameObject.CompareTag("Drop"))
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("DestroyObj"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.CompareTag("Ground"))
        {
            Rota = false;
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            OnWall = true;
            if (right == false)
            {
                right = true;
            }
            else
            {
                right = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Button"))
        {
            Rota = true;
            OnGround = false;
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            Rota = true;
            OnWall = false;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            hitPlayer = false;
            Rota = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall"))
        {
            Rota = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall"))
        {

            Rota = false;
        }

        //if (collision.gameObject.CompareTag("DestroyObj"))
        //{
        //    Destroy(this.gameObject);
        //}
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player"))
        {
            Rota = true;
        }
    }

    private void HitRay(Vector3 dir)
    {
        RaycastHit2D hit =
        Physics2D.Raycast(this.transform.position, dir, 1);
        if (hit.collider != null)
        {
            switch (dir)
            {
                case Vector3 v when v.Equals(Vector3.down):
                    {
                        hitDirDown = true;
                    }
                    break;
                case Vector3 v when v.Equals(Vector3.up):
                    {
                        hitDirUp = true;
                    }
                    break;
                case Vector3 v when v.Equals(Vector3.right):
                    {
                        hitDirRight = true;
                    }
                    break;
                case Vector3 v when v.Equals(Vector3.left):
                    {
                        hitDirLeft = true;
                    }
                    break;
            }
        }
        else
        {
            hitDirDown = false;
            hitDirLeft = false;
            hitDirRight = false;
            hitDirUp = false;
        }
    }
}
