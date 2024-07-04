using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlpha01 : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed;
    float defaultSpeed;
    bool right;
    int dir;

    Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            right = false;
            dir = 1;
            scale.x = 1;
            transform.localScale = scale;
        }
        else
        {
            right = true;
            dir = -1;
            scale.x = -1;
            transform.localScale = scale;
        }

        float speedrand = Random.Range(0, 2.0f);
        defaultSpeed = speed + speedrand;
        SpawnDraw();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.PlayerDead)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }

        transform.position += new Vector3(speed * dir * Time.deltaTime, 0, 0);

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

    private void ObjectEnemy(float x, float y)
    {
        GameObject Enemy_prefab = Resources.Load<GameObject>("EnemyAlpha01Children");
        GameObject Enemy = Instantiate(Enemy_prefab, new Vector3(x, y, 0), Quaternion.identity);
        Enemy.transform.parent = this.transform;
        return;
    }
    void SpawnDraw()
    {
        int random = Random.Range(0, 10);
        int rand = 0;
        if (random <= 3)
        {//0123
            rand = 3;
        }
        else if (random <= 10)//45678910
        {
            rand = 4;
        }
        else if (random <= 15)//1112131415
        {
            rand = 5;
        }
        else if (random == 16)//
        {
            rand = 6;
        }
        //Debug.Log(random);
        for (int i = 1; i < rand; i++)
        {
            ObjectEnemy(this.transform.position.x, this.transform.position.y + i);
        }
    }
}