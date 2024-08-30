using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject pary;
    // Start is called before the first frame update
    void Start()
    {
        pary.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        pary.transform.position = this.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"
            || collision.gameObject.tag == "Ground"
            || collision.gameObject.tag == "Wall"
            || collision.gameObject.tag == "Ceiling")
        {
            Destroy(pary.gameObject);
            Destroy(this.gameObject);
        }
    }
}
