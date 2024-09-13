using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullEnemy : MonoBehaviour
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

    public float sizeX;

    public GameObject Pary;
    bool dead;

    // Start is called before the first frame update
    void Start()
    {
        wallSpeed = false;
        dead = false;
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
        if (defaultSpeed<5)
        {
            speed = 0;
            defaultSpeed = 0;
        }
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
        if(Pary==null)
        {
            Trigger.EnemyTrigger = false;
            Destroy(this.gameObject);
        }
        if (dead)
        {
            Destroy(Pary.gameObject);
            return;
        }

        transform.position += new Vector3(defaultSpeed * dir * Time.deltaTime, 0, 0);

        if (right)
        {
            dir = 1;
            scale.x = sizeX;
            transform.localScale = scale;
        }
        else
        {
            dir = -1;
            scale.x = -sizeX;
            transform.localScale = scale;
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
            EXPController.EXP += 12.0f * PlayerMove.EXPUP;
            PlayerMove.EXPUP += 1;
            ScoreManager.bigEnemyKillCount++;
            dead = true;
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
            if (EnemyCheck == 1)
            {
                if (wallSpeed == false)
                {
                    speed += 3;
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
            scale.x *= -sizeX;
            transform.localScale = scale;
        }
    }
}
