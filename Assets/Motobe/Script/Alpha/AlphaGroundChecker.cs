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
        transform.position = PlayerObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PlayerObject.transform.position;
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
