using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProto : MonoBehaviour
{
    float posy;
    float posx;
    Rigidbody2D rb;
    [SerializeField] bool OnGround;
    [SerializeField] bool OnWall;
    bool Rota;
    int rota;
    bool wallSpeed;

    public float speed;
    float defaultSpeed;
    bool right;
    int dir;

    public int EnemyCheck;
    bool Jump;

    public GameObject EnemySkin;
    

    // Start is called before the first frame update
    void Start()
    {
        wallSpeed = false;
        rb = GetComponent<Rigidbody2D>();
        OnGround = false;
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            right = false;
            dir = 1;
        }
        else
        {
            right = true;
            dir = -1;
        }
        
        Jump = false;
        float speedrand=Random.Range(0, 2.0f);
        defaultSpeed = speed+speedrand;
        int random = Random.Range(0, 4);
        EnemyCheck = random;
        Rota = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.PlayerDead)
        {
            rb.velocity = new Vector2(0,0);
            return;
        }
        if (!PlayerMove.PlayerDead)
        {
            if (EnemyCheck <= 4)
            {
                posy = transform.position.y;
                posx = transform.position.x;
                posx += speed * Time.deltaTime * dir;
                transform.position = new Vector3(posx, posy);
            }

            if (!OnGround)
            {
                Vector2 myGravity = new Vector2(0, -9.81f * 200 * Time.deltaTime);
                rb.AddForce(myGravity);
            }
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
            if (Jump)
            {
                rb.velocity = new Vector3(0, 13, 0);
                Jump = false;
            }

            if (Rota)
            {
                EnemySkin.transform.Rotate(0, 0, 750 * rota * Time.deltaTime);
            }
            if (!Rota)
            {
                EnemySkin.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {

        if (PlayerMove.PlayerDead)
        {
            return;
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            wallSpeed = false;
            if (EnemyCheck == 0 || EnemyCheck == 3)
            {
                transform.position = new Vector3(posx, posy);
                OnGround = true;
            }

            if (EnemyCheck == 1)
            {
                transform.position = new Vector3(posx, posy + 0.01f * Time.deltaTime);
                Jump = true;
            }

            if (EnemyCheck == 2)
            {
                transform.position = new Vector3(posx, posy + 0.01f * Time.deltaTime);
                Jump = true;
                int random = Random.Range(0, 3);
                if (random == 0)
                {
                    if (right)
                    {
                        right = false;
                    }
                    else
                    {
                        right = true;
                    }
                }
            }
            if (speed != defaultSpeed)
            {
                speed = defaultSpeed;
            }
        }
        if (other.gameObject.CompareTag("Drop"))
        {
            EXPController.EXP += 5*PlayerMove.EXPUP;
            PlayerMove.EXPUP += 1;
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("DestroyObj"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (PlayerMove.PlayerDead)
        {
            return;
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            transform.position = new Vector3(posx, posy - 0.2f);
            transform.position = new Vector3(posx, posy - 0.2f);
            Rota = false;
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            OnWall = true;
            if (EnemyCheck == 1 || EnemyCheck == 2 || EnemyCheck == 3)
            {
                rb.velocity = new Vector3(0, 20, 0);
                OnGround = false;
                if (wallSpeed == false){
                    speed += 3;
                    wallSpeed = true;
                }
            }
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
        if (PlayerMove.PlayerDead)
        {
            return;
        }
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Button"))
        {
            Rota = true;
            OnGround = false;
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            if(EnemyCheck == 1 || EnemyCheck == 2 || EnemyCheck == 3)
            Rota = true;
            OnWall = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    private void OnCollisionStay2D(Collision2D collision)
    {

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }
}
