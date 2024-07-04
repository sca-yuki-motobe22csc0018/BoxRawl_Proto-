using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlpha00 : MonoBehaviour
{
    Rigidbody2D rb;
    bool wallSpeed;

    public float speed;
    float defaultSpeed;
    bool right;
    int dir;

    public int EnemyCheck;
    bool Jump;

    Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        wallSpeed = false;
        rb = GetComponent<Rigidbody2D>();
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
        float speedrand = Random.Range(0, 2.0f);
        defaultSpeed = speed + speedrand;
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.PlayerDead)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }

        transform.position += new Vector3(speed*dir*Time.deltaTime,0,0);

        if (right)
        {
            dir = 1;
            scale.x = 1;
            transform.localScale = scale;
        }
        else
        {
            dir = -1;
            scale.x = -1;
            transform.localScale = scale;
        }
        if (Jump)
        {
            rb.velocity = new Vector3(0, 13, 0);
            Jump = false;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {

        if (PlayerMove.PlayerDead)
        {
            return;
        }
        
        if (other.gameObject.CompareTag("Drop"))
        {
            EXPController.EXP += 5.0f * PlayerMove.EXPUP;
            PlayerMove.EXPUP += 1;
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (PlayerMove.PlayerDead)
        {
            return;
        }
        

        if (other.gameObject.CompareTag("Wall"))
        {
            if (EnemyCheck == 1 || EnemyCheck == 2 || EnemyCheck == 3)
            {
                if (wallSpeed == false)
                {
                    speed -= defaultSpeed-1;
                    rb.velocity = new Vector3(0, 20, 0);
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
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            
            if (EnemyCheck == 1)
            {
                Jump = true;
            }

            if (EnemyCheck == 2)
            {
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
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (PlayerMove.PlayerDead)
        {
            return;
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
