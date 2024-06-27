using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaGroundChecker : MonoBehaviour
{
    public GameObject PlayerObject;
    public static bool WallCheck;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(PlayerObject.transform.position.x,PlayerObject.transform.position.y+0.4f,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(PlayerObject.transform.position.x, PlayerObject.transform.position.y + 0.49f, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            WallCheck = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            WallCheck = false;
        }
    }
}
