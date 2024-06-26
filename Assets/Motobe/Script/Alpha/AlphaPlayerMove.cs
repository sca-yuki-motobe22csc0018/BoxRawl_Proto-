using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class AlphaPlayerMove : MonoBehaviour
{
    //Rigidbody
    private Rigidbody2D rb;

    bool Stop;
    int dir;
    int JumpCount;
    bool WallJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Stop = false;
        dir = 0;
        JumpCount = 0;
        WallJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (JumpCount == 0 && !WallJump)
            {
                rb.velocity = new Vector3(0, 20, 0);
            }
        }
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            if (Stop)
            {
                if (dir == -1)
                {
                    return;
                }
                Stop = false;
                AlphaGroundChecker.WallCheck = false;
            }
            dir = -1;
            transform.position += new Vector3(dir * 13 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            if (Stop)
            {
                if (dir == 1)
                {
                    return;
                }
                Stop = false;
                AlphaGroundChecker.WallCheck = false;
            }
            dir = 1;
            transform.position += new Vector3(dir * 13 * Time.deltaTime, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (AlphaGroundChecker.WallCheck == true)
            {
                Stop = true;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        JumpCount = 0;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            JumpCount = 1;
            if (AlphaGroundChecker.WallCheck == false)
            {
                dir = 0;
            }
        }
    }
}